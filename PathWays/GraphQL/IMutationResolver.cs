using System;

namespace PathWays.GraphQL
{
    public interface IMutationResolver
    {
        void Resolve(GraphQLMutation graphQLMutation);
    }
}