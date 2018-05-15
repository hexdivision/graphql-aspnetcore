using System;
using AutoMapper;
using GraphQL.Types;
using PathWays.Common.Utilities;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.UserPathwayService;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class UserPathwayMutationResolver : IMutationResolver
    {
        private readonly IMapper _mapper;
        private readonly IUserPathwayService _userPathwayService;

        public UserPathwayMutationResolver(IMapper mapper, IUserPathwayService userPathwayService)
        {
            _mapper = mapper;
            _userPathwayService = userPathwayService;
        }

        public void Resolve(GraphQLMutation graphQLMutation)
        {
            graphQLMutation.Field<UserPathwayType>(
                "createUserPathway",
                arguments:
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserPathwayInputType>> { Name = "userPathway" }),
                resolve: context =>
                {
                    try
                    {
                        var userPathway = context.GetArgument<UserPathway>("userPathway");

                        var result = _userPathwayService.CreateAsync(userPathway).Result;
                        return _mapper.Map<UserPathway>(result);
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                });

            graphQLMutation.Field<BooleanGraphType>(
                "deleteUserPathway",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userPathwayId", Description = "userPathwayId" }),
                resolve: context =>
                {
                    var userPathwayId = context.GetArgument<int>("userPathwayId");
                    var result = _userPathwayService.DeleteAsync(userPathwayId);
                    return result;
                });

            graphQLMutation.Field<UserPathwayType>(
                "updateUserPathway",
                arguments:
                new QueryArguments(
                    new QueryArgument<UserPathwayUpdateType> { Name = "userPathway" }),
                resolve: context =>
                {
                    try
                    {
                        var userPathway = context.GetArgument<UserPathway>("userPathway");
                        var id = userPathway.UserPathwayId;

                        if (id > 0)
                        {
                            var originalUserPathway = _userPathwayService.GetNoTrackingAsync(id).Result;
                            userPathway.ApplyPatchTo(ref originalUserPathway);
                            var result = _userPathwayService.UpdateAsync(originalUserPathway).Result;
                            return _mapper.Map<UserPathway>(result);
                        }
                        else
                        {
                            return "Model is Invalid";
                        }
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                });
        }
    }
}
