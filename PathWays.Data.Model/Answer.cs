using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class Answer : BaseEntity
    {
        public int AnswerId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public Question Question { get; set; }

        [Required]
        [DefaultValue(0)]
        public int AnswerOrder { get; set; }

        public int? AnswerType { get; set; }

        public int? PathwayToCreate { get; set; }

        public Pathway Pathway { get; set; }

        [MaxLength(500)]
        public string AnswerTitleText { get; set; }

        [MaxLength(255)]
        public string AnswerDisplayText { get; set; }

        public int? NextItemType { get; set; }

        public int? NextItemId { get; set; }

        public int? MaxNodesAhead { get; set; }

        [DefaultValue(0)]
        public bool IsDeleted { get; set; }

        public virtual ICollection<UserStep> UserSteps { get; set; }
    }
}
