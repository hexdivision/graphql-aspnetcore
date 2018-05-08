using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class Pathway : BaseEntity
    {
        public int PathwayId { get; set; }

        public int DomainId { get; set; }

        public Domain Domain { get; set; }

        [Required]
        [MaxLength(150)]
        public string PathName { get; set; }

        [Required]
        [MaxLength(2000)]
        public string PathDescription { get; set; }

        [Required]
        [MaxLength(5)]
        public string PathAbbreviation { get; set; }

        public int? FirstObjectType { get; set; }

        public int? FirstObjectId { get; set; }

        [DefaultValue(0)]
        public bool? IsDeleted { get; set; }

        [DefaultValue(0)]
        public bool IsActive { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<InlineResource> InlineResources { get; set; }

        public virtual ICollection<Ending> Endings { get; set; }
    }
}
