using System;
using System.Security.Claims;

namespace GraphQL.Authorization.Extension
{
    public class GraphQLUserContext : IProvideClaimsPrincipal
    {
        public ClaimsPrincipal User { get; set; }
    }
}
