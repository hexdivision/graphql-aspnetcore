using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
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

        public virtual ICollection<UserReport> UserReports { get; set; }

        public virtual ICollection<UserPathway> UserPathways { get; set; }

        public virtual ICollection<UserStep> UserSteps { get; set; }
    }

    ////public class UserExplorationUpdate : BaseEntity
    ////{
    ////    ////[JsonProperty("userExplorationId")]
    ////    public int UserExplorationId { get; set; }

    ////    ////[JsonProperty("organizationId")]
    ////    public int? OrganizationId { get; set; }

    ////    ////[JsonProperty("domainId")]
    ////    public int? DomainId { get; set; }

    ////    ////[JsonProperty("acceptedTerms")]
    ////    public bool? AcceptedTerms { get; set; }

    ////    [StringLength(15)]
    ////    ////[JsonProperty("accessCode")]
    ////    public string AccessCode { get; set; }

    ////    ////[JsonProperty("explorationStatus")]
    ////    public byte? ExplorationStatus { get; set; }

    ////    ////[JsonProperty("explorationCompletionDate")]
    ////    public DateTime? ExplorationCompletionDate { get; set; }

    ////    ////[JsonProperty("isDeleted")]
    ////    public bool? IsDeleted { get; set; }

    ////}
}
