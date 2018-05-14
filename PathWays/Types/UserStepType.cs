using GraphQL.Types;
using PathWays.Data.Model;

namespace PathWays.Types
{
    public class UserStepType : ObjectGraphType<UserStep>
    {
        public UserStepType()
        {
            Name = "UserStep";
            Description = "UserStep";

            Field(x => x.UserPathwayId).Description("The Id of the UserPathway.");
            Field(x => x.StepType).Description("The type of step completed.");
            Field(d => d.QuestionId, nullable: true).Description("The id of the question that was answered, required if stepType = 0 or 2");
            Field(d => d.AnswerId, nullable: true).Description("The id of the answer that was selected, required if stepType = 0 or 2");
            Field(d => d.AnswerDisplayText, nullable: true).Description("The answer display text, required if stepType = 0 or 2");
            Field(d => d.InlineResourceType, nullable: true).Description("The type of inline resource");
            Field(d => d.InlineResourceId, nullable: true).Description("The Id of the associated inline resource that was viewed, required if stepType=1.");
            Field(d => d.InternalResourceAction, nullable: true).Description("The action that was taken for the resource (0=skipped, 1=completed).");
            Field(d => d.InternalResourceRating, nullable: true).Description("The rating the user gave to the resource or result.");
            Field(d => d.ResourceTitle, nullable: true).Description("The title of the resource, required if stepType=1.");
            Field(d => d.ResourceResultText, nullable: true).Description("A short summary result that is written on completion of the resource, required if stepType=1.");
            Field(d => d.ResourceDescriptionText, nullable: true).Description("A detailed description or storage of the human readable data associated to the result.");
            Field(d => d.ResourceResultData, nullable: true).Description("The data stored with the result that can be passed into other systems.");
            Field(d => d.IsDeleted, nullable: true).Description("Whether step is marked as deleted.");
            Field(d => d.CreatedDate).Description("The creation date for the step.");
            Field(d => d.CreatedBy).Description("The user that created the step.");
            Field(d => d.ModifiedDate, nullable: true).Description("The last modified date of the step.");
            Field(d => d.ModifiedBy, nullable: true).Description("The user that has last modified the step.");
        }
    }

    public class UserStepInputType : InputObjectGraphType
    {
        public UserStepInputType()
        {
            Name = "UserStepInputType";
            Field<NonNullGraphType<IntGraphType>>("UserPathwayId");
            Field<IntGraphType>("StepType");
            Field<IntGraphType>("QuestionId");
            Field<IntGraphType>("AnswerId");
            Field<StringGraphType>("AnswerDisplayText");
            Field<IntGraphType>("InlineResourceType");
            Field<IntGraphType>("InlineResourceId");
            Field<IntGraphType>("InternalResourceAction");
            Field<IntGraphType>("InternalResourceRating");
            Field<StringGraphType>("ResourceTitle");
            Field<StringGraphType>("ResourceResultText");
            Field<StringGraphType>("ResourceDescriptionText");
            Field<StringGraphType>("ResourceResultData");
        }
    }

    ////public class UserStepUpdateType : InputObjectGraphType
    ////{
    ////}
}