using System;
using System.ComponentModel.DataAnnotations;

namespace PathWays.Data.Model
{
    public class ReportItem
    {
        public int ReportItemId { get; set; }

        public int UserReportId { get; set; }

        public UserReport UserReport { get; set; }

        public int EndingId { get; set; }

        public int EndingType { get; set; }

        [Required]
        [StringLength(255)]
        public string EndingTitle { get; set; }

        [StringLength(500)]
        public string SystemTitle { get; set; }

        [StringLength(2500)]
        public string EndingDescription { get; set; }

        public int? AssociatedServiceId { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
