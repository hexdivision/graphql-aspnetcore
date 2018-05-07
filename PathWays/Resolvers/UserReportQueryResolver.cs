using System.Collections.Generic;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.UserReportService;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class UserReportQueryResolver : IQueryResolver
    {
        private readonly IMapper _mapper;
        private readonly IUserReportService _userReportService;

        public UserReportQueryResolver(IMapper mapper, IUserReportService userReportService)
        {
            _mapper = mapper;
            _userReportService = userReportService;
        }

        public void Resolve(GraphQLQuery graphQLQuery)
        {
            graphQLQuery.Field<UserReportType>(
                "userReport",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the user report" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var userReport = _userReportService.GetUserReportAsync(id).Result;
                    var userReportType = _mapper.Map<UserReport>(userReport);
                    return userReportType;
                });

            graphQLQuery.Field<ListGraphType<UserReportType>>(
                "userReports",
                resolve: context =>
                {
                    var userReports = _userReportService.GetUserReports().Result;
                    var userReportsType = _mapper.Map<List<UserReport>>(userReports);
                    return userReportsType;
                });
        }
    }
}
