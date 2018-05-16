using System;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.UserStepService;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class UserStepMutationResolver : IMutationResolver
    {
        private readonly IMapper _mapper;
        private readonly IUserStepService _userStepService;

        public UserStepMutationResolver(IMapper mapper, IUserStepService userStepService)
        {
            _mapper = mapper;
            _userStepService = userStepService;
        }

        public void Resolve(GraphQLMutation graphQLMutation)
        {
            graphQLMutation.Field<UserStepType>(
                "createUserStep",
                arguments:
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserStepInputType>> { Name = "userStep" }),
                resolve: context =>
                {
                    try
                    {
                        var userStep = context.GetArgument<UserStep>("userStep");

                        var result = _userStepService.CreateAsync(userStep).Result;
                        return _mapper.Map<UserStep>(result);
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                });

            graphQLMutation.Field<BooleanGraphType>(
                "deleteUserStep",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userStepId", Description = "userStepId" }),
                resolve: context =>
                {
                    var userStepId = context.GetArgument<int>("userStepId");
                    var result = _userStepService.DeleteAsync(userStepId);
                    return result;
                });
        }
    }
}
