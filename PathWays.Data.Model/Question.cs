using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class Question : BaseEntity
    {
        public int QuestionId { get; set; }

        [MaxLength(20)]
        public string DisplayId { get; set; }

        [Required]
        public int DomainId { get; set; }

        public Domain Domain { get; set; }

        public int? PathwayId { get; set; }

        public Pathway Pathway { get; set; }

        [MaxLength(255)]
        public string QuestionTitle { get; set; }

        [MaxLength(1500)]
        public string QuestionTitleText { get; set; }

        public int? QuestionType { get; set; }

        public int? DeadEnds { get; set; }

        public bool? EnableChat { get; set; }

        [DefaultValue(0)]
        public bool IsDeleted { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<UserStep> UserSteps { get; set; }
    }
}
