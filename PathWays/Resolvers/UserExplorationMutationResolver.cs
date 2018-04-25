using System;
using AutoMapper;
using GraphQL.Authorization;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.UserExplorationService;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class UserExplorationMutationResolver : IMutationResolver
    {
        private readonly IMapper _mapper;
        private readonly IUserExplorationService _userExplorationService;

        public UserExplorationMutationResolver(IMapper mapper, IUserExplorationService userExplorationService)
        {
            _mapper = mapper;
            _userExplorationService = userExplorationService;
        }

        public void Resolve(GraphQLMutation graphQLMutation)
        {
            graphQLMutation.Field<UserExplorationType>(
                "createUserExploration",
                arguments:
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserExplorationInputType>> { Name = "user_exploration" }),
                resolve: context =>
                {
                    try
                    {
                        var userExploration = context.GetArgument<UserExploration>("user_exploration");
                        var result = _userExplorationService.CreateUserExploration(userExploration).Result;
                        return _mapper.Map<UserExploration>(result);
                    }
                    catch (Exception e)
                    {
                    return e.Message;
                    }
            });
        }
    }
}
