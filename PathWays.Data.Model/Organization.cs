using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PathWays.Data.Model.Base;

namespace PathWays.Data.Model
{
    public class Organization : BaseEntity
    {
        public int OrganizationId { get; set; }

        public Guid OrganizationGuid { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullName { get; set; }

        [MaxLength(200)]
        public string DisplayName { get; set; }

        public int? DisplayLogoId { get; set; }

        public bool? DisplayUserSupport { get; set; }

        public bool? DisplaySupportEmail { get; set; }

        [MaxLength(100)]
        public string SupportEmail { get; set; }

        [MaxLength(1000)]
        public string SupportEmailDescription { get; set; }

        [DefaultValue(false)]
        public bool? DisplaySupportPhone { get; set; }

        [MaxLength(15)]
        public string SupportPhone1 { get; set; }

        [MaxLength(1000)]
        public string SupportPhone1Description { get; set; }

        [MaxLength(15)]
        public string SupportPhone2 { get; set; }

        [MaxLength(1000)]
        public string SupportPhone2Description { get; set; }

        [DefaultValue(false)]
        public bool? DisplaySupportChat { get; set; }

        [MaxLength(1000)]
        public string SupportChatDescription { get; set; }

        [MaxLength(1000)]
        public string SupportChatUrl { get; set; }

        public int TimeZoneOffset { get; set; }

        [DefaultValue(1)]
        public int? LicenseType { get; set; }

        public decimal? PerVisitFee { get; set; }

        public decimal? PerComplationFee { get; set; }

        public decimal? PerServiceAccessFee { get; set; }

        public decimal? FlatMonthlyFee { get; set; }

        [DefaultValue(1)]
        public int? OrganizationStatus { get; set; }
    }
}
