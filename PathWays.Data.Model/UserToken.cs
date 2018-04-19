﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PathWays.Data.Model
{
    public class UserToken
    {
        public int UserTokenId { get; set; }

        [StringLength(250)]
        [Required]
        public string AuthToken { get; set; }

        [Required]
        public DateTime IssuedOn { get; set; }

        [Required]
        public DateTime ExpiresOn { get; set; }

        public SystemUser SystemUser { get; set; }

        public int? SystemUserId { get; set; }

        public Guid? SystemUserGuid { get; set; }

        [Required]
        public int RoleId { get; set; }

        public int? ParticipantId { get; set; }
    }
}