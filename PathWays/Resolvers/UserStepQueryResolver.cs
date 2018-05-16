using System.Collections.Generic;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.UserStepService;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class UserStepQueryResolver : IQueryResolver
    {
        private readonly IMapper _mapper;
        private readonly IUserStepService _userStepService;

        public UserStepQueryResolver(IMapper mapper, IUserStepService userStepService)
        {
            _mapper = mapper;
            _userStepService = userStepService;
        }

        public void Resolve(GraphQLQuery graphQLQuery)
        {
            graphQLQuery.Field<UserStepType>(
                "userStep",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the user step" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var userStep = _userStepService.GetByIdAsync(id).Result;
                    var userStepType = _mapper.Map<UserStep>(userStep);
                    return userStepType;
                });

            graphQLQuery.Field<ListGraphType<UserStepType>>(
                "userSteps",
                resolve: context =>
                {
                    var userSteps = _userStepService.GetAllAsync().Result;
                    var userStepsType = _mapper.Map<List<UserStep>>(userSteps);
                    return userStepsType;
                });
        }
    }
}
