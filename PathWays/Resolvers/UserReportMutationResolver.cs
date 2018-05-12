using System;
using AutoMapper;
using GraphQL.Types;
using PathWays.Common.Utilities;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.UserReportService;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class UserReportMutationResolver : IMutationResolver
    {
        private readonly IMapper _mapper;
        private readonly IUserReportService _userReportService;

        public UserReportMutationResolver(IMapper mapper, IUserReportService userReportService)
        {
            _mapper = mapper;
            _userReportService = userReportService;
        }

        public void Resolve(GraphQLMutation graphQLMutation)
        {
            graphQLMutation.Field<UserReportType>(
                "createUserReport",
                arguments:
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserReportInputType>> { Name = "userReport" }),
                resolve: context =>
                {
                    try
                    {
                        var userReport = context.GetArgument<UserReport>("userReport");

                        var result = _userReportService.CreateAsync(userReport).Result;
                        return _mapper.Map<UserReport>(result);
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                });

            graphQLMutation.Field<BooleanGraphType>(
                "deleteUserReport",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userReportId", Description = "userReportId" }),
                resolve: context =>
                {
                    var userReportId = context.GetArgument<int>("userReportId");
                    var result = _userReportService.DeleteAsync(userReportId);
                    return result;
                });

            graphQLMutation.Field<UserReportType>(
                "updateUserReport",
                arguments:
                new QueryArguments(
                    new QueryArgument<UserReportUpdateType> { Name = "userReport" }),
                resolve: context =>
                {
                    try
                    {
                        var userReport = context.GetArgument<UserReport>("userReport");
                        var id = userReport.UserReportId;

                        if (id > 0)
                        {
                            var originalUserReport = _userReportService.GetUserReportAsync(id).Result;

                            var userReportDict = context.GetArgumentDictionary("userReport");
                            originalUserReport.PatchFromDictionary(userReportDict);

                            var result = _userReportService.UpdateAsync(originalUserReport).Result;
                            return _mapper.Map<UserReport>(result);
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
