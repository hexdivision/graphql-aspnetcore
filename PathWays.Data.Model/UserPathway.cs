using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class UserPathway : BaseEntity
    {
        public int UserPathwayId { get; set; }

        public int UserExplorationId { get; set; }

        public UserExploration UserExploration { get; set; }

        public int PathwayType { get; set; }

        public int? PathwayId { get; set; }

        public Pathway Pathway { get; set; }

        [StringLength(100)]
        public string PathwayTitle { get; set; }

        public int? PathwayStatus { get; set; }

        public DateTime? PathwayCompletionDate { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual ICollection<UserStep> UserSteps { get; set; }
    }
}
