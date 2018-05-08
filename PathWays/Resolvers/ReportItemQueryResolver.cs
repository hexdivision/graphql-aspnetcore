using System.Collections.Generic;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.ReportItem;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class ReportItemQueryResolver : IQueryResolver
    {
        private readonly IMapper _mapper;
        private readonly IReportItemService _reportItemService;

        public ReportItemQueryResolver(IMapper mapper, IReportItemService reportItemService)
        {
            _mapper = mapper;
            _reportItemService = reportItemService;
        }

        public void Resolve(GraphQLQuery graphQLQuery)
        {
            graphQLQuery.Field<ReportItemType>(
                "reportItem",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the report item" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var reportItem = _reportItemService.GetByIdAsync(id).Result;
                    var reportItemType = _mapper.Map<ReportItem>(reportItem);
                    return reportItemType;
                });

            graphQLQuery.Field<ListGraphType<ReportItemType>>(
                "reportItems",
                resolve: context =>
                {
                    var reportItems = _reportItemService.GetAllAsync().Result;
                    var reportItemsType = _mapper.Map<List<ReportItem>>(reportItems);
                    return reportItemsType;
                });
        }
    }
}
