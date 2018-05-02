﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Execution;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
            // http://graphql.org/learn/serving-over-http/#http-methods-headers-and-body

            string body = null;
            if (request.Method == "POST")
            {
                // Read request body
                using (var sr = new StreamReader(request.Body))
                {
                    body = await sr.ReadToEndAsync();
                }
            }

            MediaTypeHeaderValue.TryParse(request.ContentType, out MediaTypeHeaderValue contentType);

            GraphQlParameters parameters;

            switch (contentType.MediaType)
            {
                case "application/json":
                    // Parse request as json
                    parameters = JsonConvert.DeserializeObject<GraphQlParameters>(body);
                    break;

                case "application/graphql":
                    // The whole body is the query
                    parameters = new GraphQlParameters { Query = body };
                    break;

                default:
                    // Don't parse anything
                    parameters = new GraphQlParameters();
                    break;
            }

            string query = request.Query["query"];

            // Query string "query" overrides a query in the body
            parameters.Query = query ?? parameters.Query;

            return parameters;
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