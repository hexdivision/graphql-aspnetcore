using System;
using System.Collections.Generic;
using AutoMapper;
using GraphQL.Types;
using PathWays.GraphQL;
using PathWays.Services.UserExplorationService;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class UserExplorationQueryResolver : IQueryResolver
    {
        private readonly IUserExplorationService _userExplorationService;
        private readonly IMapper _mapper;

        public UserExplorationQueryResolver(IUserExplorationService userExplorationService, IMapper mapper)
        {
            _userExplorationService = userExplorationService;
            _mapper = mapper;
        }

        public void Resolve(GraphQLQuery graphQLQuery)
        {
            graphQLQuery.Field<UserExplorationType>(
                "user_exploration",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the user exploration" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var userExploration = _userExplorationService.GetUserExploration(id);
                    var userExplorationType = _mapper.Map<UserExplorationType>(userExploration);
                    return userExplorationType;
                });

            graphQLQuery.Field<ListGraphType<UserExplorationType>>(
                "user_explorations",
                resolve: context =>
                {
                    var userExplorations = _userExplorationService.GetUserExplorations();
                    var userExplorationsType = _mapper.Map<List<UserExplorationType>>(userExplorations);
                    return userExplorationsType;
                });
        }
    }
}
