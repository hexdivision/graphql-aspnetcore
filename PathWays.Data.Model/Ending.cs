using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class Ending : BaseEntity
    {
        public int EndingId { get; set; }

        public int DomainId { get; set; }

        public Domain Domain { get; set; }

        public int? PathwayId { get; set; }

        public Pathway Pathway { get; set; }

        public int EndingType { get; set; }

        [Required]
        [MinLength(255)]
        public string EndingTitle { get; set; }

        [MinLength(500)]
        public string SystemTitle { get; set; }

        [MinLength(2500)]
        public string EndingDescription { get; set; }

        [MinLength(2500)]
        public string ReturnInstructions { get; set; }

        public int ReturnNextItemType { get; set; }

        public int? ReturnNextItemId { get; set; }

        public int? ServiceId { get; set; }

        [DefaultValue(0)]
        public int? IsDeleted { get; set; }
    }
}
