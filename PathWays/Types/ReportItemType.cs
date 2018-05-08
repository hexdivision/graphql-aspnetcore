using GraphQL.Types;
using PathWays.Data.Model;

namespace PathWays.Types
{
    public class ReportItemType : ObjectGraphType<ReportItem>
    {
        public ReportItemType()
        {
            Name = "ReportItem";
            Description = "ReportItem";

            Field(x => x.ReportItemId).Description("The Id of the Report.");
            Field(x => x.UserReportId).Description("The Id of the associated UserReport.");
            Field(x => x.EndingId).Description("The Id of the associated ending");
            Field(d => d.EndingType).Description("The associated ending type");
            Field(d => d.EndingTitle).Description("The associated ending title");
            Field(d => d.EndingDescription, nullable: true).Description("The associated ending description");
            Field(d => d.SystemTitle, nullable: true).Description("The associated ending system type");
            Field(d => d.AssociatedServiceId, nullable: true).Description("The associated service");
            Field(d => d.IsDeleted, nullable: true).Description("Whether report is marked as deleted.");
            Field(d => d.CreatedDate).Description("The creation date for the report.");
            Field(d => d.ModifiedDate, nullable: true).Description("The last modified date of the report.");
        }
    }

    public class ReportItemInputType : InputObjectGraphType
    {
        public ReportItemInputType()
        {
            Name = "ReportItemInputType";
            Field<NonNullGraphType<IntGraphType>>("UserReportId");
            Field<NonNullGraphType<IntGraphType>>("EndingId");
            Field<NonNullGraphType<IntGraphType>>("EndingType");
            Field<NonNullGraphType<StringGraphType>>("EndingTitle");
            Field<StringGraphType>("EndingDescription");
            Field<StringGraphType>("SystemTitle");
            Field<IntGraphType>("AssociatedServiceId");
        }
    }

    public class ReportItemUpdateType : InputObjectGraphType
    {
        public ReportItemUpdateType()
        {
            Name = "ReportItemUpdateType";
            Field<NonNullGraphType<IntGraphType>>("EndingId");
            Field<NonNullGraphType<IntGraphType>>("EndingType");
            Field<NonNullGraphType<StringGraphType>>("EndingTitle");
            Field<StringGraphType>("EndingDescription");
            Field<StringGraphType>("SystemTitle");
            Field<IntGraphType>("AssociatedServiceId");
        }
    }
}
