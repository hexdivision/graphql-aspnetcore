using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class SystemUser : BaseEntity
    {
        [Key]
        public int SystemUserId { get; set; }

        [Required]
        public Guid UserGuid { get; set; }

        public bool? IsActive { get; set; }

        [Required]
        public bool AdminAccess { get; set; }

        [StringLength(50)]
        [Required]
        public string Username { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string AccountEmail { get; set; }

        [StringLength(15)]
        public string AccountMobile { get; set; }

        public bool? AcceptsTextMessages { get; set; }

        public SystemUserRole SystemUserRole { get; set; }

        public int SystemUserRoleId { get; set; }
    }
}
