using System.Collections.Generic;
using System.ComponentModel;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class UserReport : BaseEntity
    {
        public int UserReportId { get; set; }

        public int UserExplorationId { get; set; }

        public UserExploration UserExploration { get; set; }

        public int? UserReportStatus { get; set; }

        [DefaultValue(0)]
        public bool? IsDeleted { get; set; }

        public virtual ICollection<ReportItem> ReportItems { get; set; }
    }
}