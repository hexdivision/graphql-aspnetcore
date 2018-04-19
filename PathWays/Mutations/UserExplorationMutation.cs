using System;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.Services.UserExplorationService;
using PathWays.Types;

namespace PathWays.Mutations
{
    public class UserExplorationMutation : ObjectGraphType
    {
        public UserExplorationMutation(IUserExplorationService userExplorationService, IMapper mapper)
        {
            Name = "Mutation";

            Field<UserExplorationType>(
                "createUserExploration",
                arguments:
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserExplorationInputType>> { Name = "user_exploration" }),
                resolve: context =>
                {
                    try
                    {
                        var userExploration = context.GetArgument<UserExploration>("user_exploration");
                        var result = userExplorationService.CreateUserExploration(userExploration);
                        return mapper.Map<UserExplorationType>(result);
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                });
        }
    }
}
