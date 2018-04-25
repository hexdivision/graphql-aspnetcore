using GraphQL.Types;
using PathWays.Data.Model;

namespace PathWays.Types
{
    public class UserExplorationType : ObjectGraphType<UserExploration>
    {
        public UserExplorationType()
        {
            Name = "UserExploration";
            Description = "UserExploration";

            Field(x => x.UserExplorationId).Description("The Id of the UserExploration.");
            Field(x => x.OrganizationId).Description("The associated organization of the exploration.");
            Field(d => d.DomainId).Description("The associated domain of the exploration.");
            Field(d => d.AcceptedTerms, nullable: true).Description("Whether the user accepted terms (0=False, 1=True).");
            Field(d => d.AccessCode, nullable: true).Description("The 7 digit generated unique access code.");
            ////Field(d => d.ExplorationStatus, nullable: true).Description("The status of the exploration (o=in progress, 1=completed).");
            Field(d => d.ExplorationCompletionDate, nullable: true).Description("The date that the exploration was completed.");
            Field(d => d.IsDeleted, nullable: true).Description("Whether exploration is marked as deleted.");
            Field(d => d.CreatedDate).Description("The creation date for the exploration.");
            Field(d => d.ModifiedDate, nullable: true).Description("The last modified date of the exploration.");
        }
    }

    public class UserExplorationInputType : InputObjectGraphType
    {
        public UserExplorationInputType()
        {
            Name = "UserExplorationInputType";
            Field<NonNullGraphType<IntGraphType>>("DomainId");
        }
    }
}
