using System.ComponentModel.DataAnnotations;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class UserStep : BaseEntity
    {
        public int UserStepId { get; set; }

        public int UserExplorationId { get; set; }

        public UserExploration UserExploration { get; set; }

        public int UserPathwayId { get; set; }

        public UserPathway UserPathway { get; set; }

        public int? StepCount { get; set; }

        public int StepType { get; set; }

        public int? QuestionId { get; set; }

        public Question Question { get; set; }

        public int? AnswerId { get; set; }

        public Answer Answer { get; set; }

        public string AnswerDisplayText { get; set; }

        public int? InlineResourceType { get; set; }

        public int? InlineResourceId { get; set; }

        public InlineResource InlineResource { get; set; }

        public int? InternalResourceAction { get; set; }

        public int? InternalResourceRating { get; set; }

        [StringLength(200)]
        public string ResourceTitle { get; set; }

        [StringLength(2000)]
        public string ResourceResultText { get; set; }

        public string ResourceDescriptionText { get; set; }

        public string ResourceResultData { get; set; }

        public bool? IsDeleted { get; set; }
    }
}