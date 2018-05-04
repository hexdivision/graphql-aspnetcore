using System;
using System.Collections.Generic;

namespace PathWays.Data.Model
{
    public class UserReport
    {
        public int UserReportId { get; set; }

        public int UserExplorationId { get; set; }

        public UserExploration UserExploration { get; set; }

        public int? UserReportStatus { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<ReportItem> ReportItems { get; set; }
    }
}
