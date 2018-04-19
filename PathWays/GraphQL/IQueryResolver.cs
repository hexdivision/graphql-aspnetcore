using System;

namespace PathWays.GraphQL
{
    public interface IQueryResolver
    {
        void Resolve(GraphQLQuery graphQLQuery);
    }
}
