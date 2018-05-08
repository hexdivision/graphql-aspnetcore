using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class ReportItem : BaseEntity
    {
        public int ReportItemId { get; set; }

        public int UserReportId { get; set; }

        public UserReport UserReport { get; set; }

        public int EndingId { get; set; }

        public Ending Ending { get; set; }

        public int EndingType { get; set; }

        [Required]
        [StringLength(255)]
        public string EndingTitle { get; set; }

        [StringLength(500)]
        public string SystemTitle { get; set; }

        [StringLength(2500)]
        public string EndingDescription { get; set; }

        public int? AssociatedServiceId { get; set; }

        [DefaultValue(0)]
        public bool? IsDeleted { get; set; }
    }
}
