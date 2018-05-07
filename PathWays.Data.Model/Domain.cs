using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class Domain : BaseEntity
    {
        public int DomainId { get; set; }

        public int? OrganizationId { get; set; }

        public Organization Organization { get; set; }

        [MaxLength(150)]
        public string DomainTitle { get; set; }

        [MaxLength(500)]
        public string DomainDescription { get; set; }

        [MaxLength(7)]
        public string DomainAbbreviation { get; set; }

        [MaxLength(20)]
        public string DomainEmbedCode { get; set; }

        public int? FirstObjectType { get; set; }

        public int? FirstObjectId { get; set; }

        public bool? EnforceTerms { get; set; }

        public string TermsOfUseHtml { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Pathway> Pathways { get; set; }
    }
}
