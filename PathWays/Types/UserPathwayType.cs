using GraphQL.Types;
using PathWays.Data.Model;

namespace PathWays.Types
{
    public class UserPathwayType : ObjectGraphType<UserPathway>
    {
        public UserPathwayType()
        {
            Name = "UserPathway";
            Description = "UserPathway";

            Field(x => x.UserPathwayId).Description("The Id of the UserPathway.");
            Field(x => x.UserExplorationId).Description("The Id of the associated exploration.");
            Field(x => x.PathwayType).Description("The type of pathway. 0=linked to pathway, 1=generic information");
            Field(d => d.PathwayId).Description("The associated Pathway. Required if PathwayType=0");
            Field(d => d.PathwayTitle).Description("The title of the pathway");
            Field(d => d.PathwayStatus, nullable: true).Description("The status of the pahway. 0=not started, 1=in progress, 2=completed");
            Field(d => d.PathwayCompletionDate, nullable: true).Description("The date the pathway was completed");
            Field(d => d.IsDeleted, nullable: true).Description("Whether report is marked as deleted.");
            Field(d => d.CreatedDate).Description("The creation date for the pathway.");
            Field(d => d.CreatedBy).Description("The user that created the pathway.");
            Field(d => d.ModifiedDate, nullable: true).Description("The last modified date of the pathway.");
            Field(d => d.ModifiedBy, nullable: true).Description("The user that has last modified the pathway.");
        }
    }

    public class UserPathwayInputType : InputObjectGraphType
    {
        public UserPathwayInputType()
        {
            Name = "UserPathwayInputType";
            Field<NonNullGraphType<IntGraphType>>("UserExplorationId");
            Field<NonNullGraphType<IntGraphType>>("PathwayType");
            Field<IntGraphType>("PathwayId");
            Field<StringGraphType>("PathwayTitle");
            Field<IntGraphType>("PathwayStatus");
            Field<DateGraphType>("PathwayCompletionDate");
        }
    }

    public class UserPathwayUpdateType : InputObjectGraphType
    {
        public UserPathwayUpdateType()
        {
            Name = "UserPathwayUpdateType";
            Field<NonNullGraphType<IntGraphType>>("UserExplorationId");
            Field<StringGraphType>("PathwayTitle");
            Field<IntGraphType>("PathwayStatus");
            Field<DateGraphType>("PathwayCompletionDate");
        }
    }
}
