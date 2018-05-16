using System;
using AutoMapper;
using GraphQL.Types;
using PathWays.Common.Utilities;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.ReportItem;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class ReportItemMutationResolver : IMutationResolver
    {
        private readonly IMapper _mapper;
        private readonly IReportItemService _reportItemService;

        public ReportItemMutationResolver(IMapper mapper, IReportItemService reportItemService)
        {
            _mapper = mapper;
            _reportItemService = reportItemService;
        }

        public void Resolve(GraphQLMutation graphQLMutation)
         {
            graphQLMutation.Field<ReportItemType>(
                "createReportItem",
                arguments:
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReportItemInputType>> { Name = "reportItem" }),
                resolve: context =>
                {
                    try
                    {
                        var reportItem = context.GetArgument<ReportItem>("reportItem");

                        var result = _reportItemService.CreateAsync(reportItem).Result;
                        return _mapper.Map<ReportItem>(result);
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                });

            graphQLMutation.Field<BooleanGraphType>(
                "deleteReportItem",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "reportItemId", Description = "reportItemId" }),
                resolve: context =>
                {
                    var reportItemId = context.GetArgument<int>("reportItemId");
                    var result = _reportItemService.DeleteAsync(reportItemId);
                    return result;
                });
/*
            graphQLMutation.Field<ReportItemType>(
                "updateReportItem",
                arguments:
                new QueryArguments(
                    new QueryArgument<ReportItemUpdateType> { Name = "reportItem" }),
                resolve: context =>
                {
                    try
                    {
                        var reportItem = context.GetArgument<ReportItem>("reportItem");
                        var id = reportItem.ReportItemId;

                        if (id > 0)
                        {
                            var originalReportItem = _reportItemService.GetByIdAsync(id).Result;

                            var reportDict = context.GetArgumentDictionary("reportItem");
                            originalReportItem.PatchFromDictionary(reportDict);

                            var result = _reportItemService.UpdateAsync(originalReportItem).Result;
                            return _mapper.Map<ReportItem>(result);
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
*/
        }
    }
}
