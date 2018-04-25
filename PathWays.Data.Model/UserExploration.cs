using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class UserExploration : BaseEntity
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

        public virtual ICollection<UserExplorationToken> UserExplorationTokens { get; set; }
    }
}
