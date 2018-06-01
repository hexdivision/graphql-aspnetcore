using System;
using System.Security.Claims;
using GraphQL.Authorization;
using GraphQL.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace PathWays.GraphQL.Authorization
{
    public static class GraphQLAuthorizationExtension
    {
        public static void AddGraphQLAuth(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
            services.AddTransient<IValidationRule, AuthorizationValidationRule>();

            services.TryAddSingleton(s =>
            {
                var authSettings = new AuthorizationSettings();

                authSettings.AddPolicy("Admin", _ => _.RequireClaim(ClaimTypes.Role, "Admin"));
                authSettings.AddPolicy("User", _ => _.RequireClaim(ClaimTypes.Role, "User"));

                return authSettings;
            });
        }
    }
}
