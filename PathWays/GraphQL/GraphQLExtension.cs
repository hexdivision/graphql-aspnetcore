using System;
using System.Collections.Generic;
using GraphQL.Types;

namespace PathWays.GraphQL
{
    public static class GraphQLExtension
    {
        public static IReadOnlyDictionary<string, object> GetArgumentDictionary(this ResolveFieldContext<object> context, string argumentName)
        {
            return (IReadOnlyDictionary<string, object>)context.Arguments.GetValueOrDefault(argumentName);
        }
    }
}
