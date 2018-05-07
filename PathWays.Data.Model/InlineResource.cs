using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class InlineResource : BaseEntity
    {
        public int InlineResourceId { get; set; }

        public int DomainId { get; set; }

        public Domain Domain { get; set; }

        public int PathwayId { get; set; }

        public Pathway Pathway { get; set; }

        [MaxLength(20)]
        public string DisplayId { get; set; }

        public int ResourceType { get; set; }

        [DefaultValue(0)]
        public bool? SharePublicly { get; set; }

        [MaxLength(255)]
        public string ResourceTitle { get; set; }

        [MaxLength(2000)]
        public string ResourceDescription { get; set; }

        [MaxLength(2000)]
        public string ResourceInstructions { get; set; }

        public string TemplateHtml { get; set; }

        public int? TemplateDoc { get; set; }

        [MaxLength(1000)]
        public string ExternalUrl { get; set; }

        public int? NextItemType { get; set; }

        public int? NextItemId { get; set; }

        [DefaultValue(0)]
        public int? IsDeleted { get; set; }
    }
}
