using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Execution;
using GraphQL.Extension;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GraphQl.AspNetCore
{
    public class GraphQlMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ISchemaProvider _schemaProvider;

        private readonly GraphQlMiddlewareOptions _options;

        private readonly IDocumentExecuter _executer;

        private readonly IEnumerable<IDocumentExecutionListener> _executionListeners;

        public GraphQlMiddleware(
            RequestDelegate next,
            ISchemaProvider schemaProvider,
            GraphQlMiddlewareOptions options,
            IDocumentExecuter executer,
            IEnumerable<IDocumentExecutionListener> executionListeners)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _schemaProvider = schemaProvider ?? throw new ArgumentNullException(nameof(schemaProvider));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _executer = executer ?? throw new ArgumentNullException(nameof(options));
            _executionListeners = executionListeners ?? new IDocumentExecutionListener[0];
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var logger = httpContext.RequestServices.GetService<ILogger<GraphQlMiddleware>>();

            HttpRequest request = httpContext.Request;
            HttpResponse response = httpContext.Response;

            response.Headers.Add(CorsConstants.AccessControlAllowOrigin, CorsConstants.AnyOrigin);
            response.Headers.Add(CorsConstants.AccessControlAllowCredentials, "true");
            response.Headers.Add(CorsConstants.AccessControlAllowMethods, "GET, HEAD, OPTIONS, POST, PUT");
            response.Headers.Add(CorsConstants.AccessControlAllowHeaders, "Authorization, Origin, Accept, X-Requested-With, Content-Type, Token");

            // GraphQL HTTP only supports GET and POST methods.
            if (request.Method != "GET" && request.Method != "POST")
            {
                if (request.Method == "OPTIONS")
                {
                    response.StatusCode = StatusCodes.Status200OK;
                    response.ContentType = "application/json; charset=utf-8";

                    return;
                }

                response.StatusCode = StatusCodes.Status405MethodNotAllowed;

                return;
            }

            // Check authorization
            if (_options.AuthorizationPolicy != null)
            {
                var authorizationService = httpContext.RequestServices.GetRequiredService<IAuthorizationService>();
                var authzResult =
                    await authorizationService.AuthorizeAsync(httpContext.User, _options.AuthorizationPolicy);

                if (!authzResult.Succeeded)
                {
                    await httpContext.ForbidAsync();
                    return;
                }
            }

            GraphQlParameters parameters = await GetParametersAsync(request);

            ISchema schema = _schemaProvider.Create(httpContext.RequestServices);

            var result = await _executer.ExecuteAsync(options =>
            {
                options.Schema = schema;
                options.Query = parameters.Query;
                options.OperationName = parameters.OperationName;
                options.Inputs = parameters.Variables.ToInputs();
                options.CancellationToken = httpContext.RequestAborted;
                options.ComplexityConfiguration = _options.ComplexityConfiguration;

                if (_options.BuildUserContext != null)
                {
                    options.UserContext = _options.BuildUserContext.Invoke(httpContext).Result;
                }
                else
                {
                    options.UserContext = httpContext;
                }

                options.Root = httpContext;

                options.ExposeExceptions = _options.ExposeExceptions;
                options.ValidationRules = _options.ValidationRules;
                ConfigureDocumentExecutionListeners(options, _executionListeners);
            });

            if (result.Errors?.Count > 0)
            {
                logger.LogError("GraphQL Result {Errors}", result.Errors);
            }

            var writer = new DocumentWriter(indent: _options.FormatOutput);
            var json = writer.Write(result);

            response.StatusCode = StatusCodes.Status200OK;
            response.ContentType = "application/json; charset=utf-8";

            await response.WriteAsync(json);
        }

        private static async Task<GraphQlParameters> GetParametersAsync(HttpRequest request)
        {
            GraphQlParameters parameters = null;

            // http://graphql.org/learn/serving-over-http/#http-methods-headers-and-body
            if (request.Method == "POST")
            {
                MediaTypeHeaderValue.TryParse(request.ContentType, out MediaTypeHeaderValue contentType);

                switch (contentType.MediaType.Value)
                {
                    case "application/json":
                        // Parse request as json
                        var bodyJson = GetGraphQLParametersFromBody(request.Body);
                        parameters = JsonConvert.DeserializeObject<GraphQlParameters>(bodyJson);
                        break;

                    case "application/graphql":
                        // The whole body is the query
                        var bodyGraphQL = GetGraphQLParametersFromBody(request.Body);
                        parameters = new GraphQlParameters { Query = bodyGraphQL };
                        break;
                    case "multipart/form-data":
                        parameters = await GetGraphQLParametersFromMultipartBody(request.Body, contentType);
                        break;
                    default:
                        // Don't parse anything
                        parameters = new GraphQlParameters();
                        break;
                }

                string query = request.Query["query"];

                // Query string "query" overrides a query in the body
                parameters.Query = query ?? parameters.Query;
            }

            return parameters;
        }

        private static string GetGraphQLParametersFromBody(Stream stream)
        {
            string body = null;
            using (var sr = new StreamReader(stream))
            {
                body = sr.ReadToEndAsync().Result;
            }

            return body;
        }

        private static async Task<GraphQlParameters> GetGraphQLParametersFromMultipartBody(Stream body, MediaTypeHeaderValue contentType)
        {
            var graphqlBody = string.Empty;

            var formAccumulator = default(KeyValueAccumulator);

            var boundary = MultipartRequestHelper.GetBoundary(contentType);

            using (var sr = new StreamReader(body))
            {
                var reader = new MultipartReader(boundary, sr.BaseStream);

                var section = await reader.ReadNextSectionAsync();

                while (section != null)
                {
                    var hasContentDispositionHeader =
                        ContentDispositionHeaderValue.TryParse(
                            section.ContentDisposition,
                            out ContentDispositionHeaderValue contentDisposition);

                    if (hasContentDispositionHeader)
                    {
                        if (contentDisposition.IsFormDisposition())
                        {
                            formAccumulator = await MultipartRequestHelper.AccumulateForm(formAccumulator, section, contentDisposition);
                        }
                    }

                    section = await reader.ReadNextSectionAsync();
                }
            }

            var formResults = formAccumulator.GetResults();
            var operations = formResults.GetValueOrDefault("operations");
            var variables = formResults.GetValueOrDefault("map");

            return new GraphQlParameters { Query = operations.ToString(), Variables = JObject.Parse(variables.ToString()) };
        }

        private static void ConfigureDocumentExecutionListeners(ExecutionOptions options,
            IEnumerable<IDocumentExecutionListener> listeners)
        {
            Debug.Assert(listeners != null, "listeners != null");

            var listenerSet = new HashSet<IDocumentExecutionListener>(options.Listeners);
            listenerSet.UnionWith(listeners);

            options.Listeners.Clear();
            foreach (var listener in listenerSet)
            {
                options.Listeners.Add(listener);
            }
        }
    }
}