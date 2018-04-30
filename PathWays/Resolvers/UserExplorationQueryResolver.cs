using System;
using System.Collections.Generic;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
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
                "userExploration",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the user exploration" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var userExploration = _userExplorationService.GetUserExploration(id).Result;
                    var userExplorationType = _mapper.Map<UserExploration>(userExploration);
                    return userExplorationType;
                });

            graphQLQuery.Field<ListGraphType<UserExplorationType>>(
                "userExplorations",
                resolve: context =>
                {
                    var userExplorations = _userExplorationService.GetUserExplorations().Result;
                    var userExplorationsType = _mapper.Map<List<UserExploration>>(userExplorations);
                    return userExplorationsType;
                });
        }
    }
}
