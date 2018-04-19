using System.Collections.Generic;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.Services.UserExplorationService;
using PathWays.Types;

namespace PathWays.Queries
{
    public class UserExplorationQuery : ObjectGraphType
    {
        public UserExplorationQuery(IUserExplorationService userExplorationService, IMapper mapper)
        {
            Name = "Query";

            Field<UserExplorationType>(
                "user_exploration",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the user exploration" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var userExploration = userExplorationService.GetUserExploration(id);
                    var userExplorationType = mapper.Map<UserExplorationType>(userExploration);
                    return userExplorationType;
                });

            Field<ListGraphType<UserExplorationType>>(
                "user_explorations",
                resolve: context =>
                {
                    var userExplorations = userExplorationService.GetUserExplorations();
                    var userExplorationsType = mapper.Map<List<UserExplorationType>>(userExplorations);
                    return userExplorationsType;
                });
        }
    }
}
