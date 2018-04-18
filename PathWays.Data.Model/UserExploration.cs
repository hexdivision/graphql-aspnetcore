using System;
using System.ComponentModel.DataAnnotations;

namespace PathWays.Data.Model
{
    public class UserExploration
    {
        public int UserExplorationId { get; set; }

        public int OrganizationId { get; set; }

        public int DomainId { get; set; }

        public bool? AcceptedTerms { get; set; }

        [StringLength(15)]
        public string AccessCode { get; set; }

        public byte? ExplorationStatus { get; set; }

        public DateTime ExplorationCompletionDate { get; set; }

        public bool? IsDeleted { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
