using System;
using System.ComponentModel.DataAnnotations;

namespace PathWays.Data.Model
{
    public class UserExplorationToken
    {
        public int UserExplorationTokenId { get; set; }

        [Required]
        [StringLength(250)]
        public string AuthToken { get; set; }

        [Required]
        public DateTime ExpiresOn { get; set; }

        [Required]
        public DateTime IssuedOn { get; set; }

        [StringLength(15)]
        public string AccessCode { get; set; }

        public byte RoleId { get; set; }

        public int? ExplorationId { get; set; }

        public int? SystemUserId { get; set; }
    }
}
