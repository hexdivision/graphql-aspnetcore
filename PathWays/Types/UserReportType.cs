using GraphQL.Types;
using PathWays.Data.Model;

namespace PathWays.Types
{
    public class UserReportType : ObjectGraphType<UserReport>
    {
        public UserReportType()
        {
            Name = "UserReport";
            Description = "UserReport";

            Field(x => x.UserReportId).Description("The Id of the UserReport.");
            Field(x => x.UserExplorationId).Description("The unique Id of the associated exploration.");
            Field(d => d.UserReportStatus, nullable: true).Description("The status of the report (0=inclomplete, 1=complete)");
            Field(d => d.IsDeleted, nullable: true).Description("Whether report is marked as deleted.");
            Field(d => d.CreatedDate).Description("The creation date for the exploration.");
            Field(d => d.ModifiedDate, nullable: true).Description("The last modified date of the exploration.");
        }
    }

    public class UserReportInputType : InputObjectGraphType
    {
        public UserReportInputType()
        {
            Name = "UserReportInputType";
            Field<NonNullGraphType<IntGraphType>>("UserExplorationId");
            Field<IntGraphType>("UserReportStatus");
        }
    }

    public class UserReportUpdateType : InputObjectGraphType
    {
        public UserReportUpdateType()
        {
            Name = "UserReportUpdateType";
            Field<NonNullGraphType<IntGraphType>>("UserExplorationId");
            Field<IntGraphType>("DomainId");
            Field<IntGraphType>("OrganizationId");
            Field<DateGraphType>("ExplorationCompletionDate");
        }
    }
}
