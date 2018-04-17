using System.ComponentModel;

namespace PathWays.Common.Utilities
{
    /// <summary>
    /// Enums Utilities
    /// </summary>
    public enum Roles
    {
        [Description("Staff User")]
        StaffUser = 1,
        [Description("External User")]
        ExternalUser = 2,
        [Description("Guest User")]
        GuestUser = 3,
        [Description("Access Code User")]
        AccessCodeUser = 4,
        [Description("Office Pay User")]
        OfficePayUser = 5
    }

    /// <summary>
    /// Errors and descriptions
    /// </summary>
    public enum Errors
    {
        /// <summary>
        /// Transaction rollback
        /// </summary>
        [Description("TransactionRollback")]
        TransactionRollback = -1,
        ConcurrencyUpdate = -2,
    }

    /// <summary>
    /// System settings type
    /// </summary>
    public enum SystemSettingsType
    {
        /// <summary>
        /// Payment settings
        /// </summary>
        Payment = 0,

        /// <summary>
        /// PDF Generation settings
        /// </summary>
        PdfGeneration = 1,

        /// <summary>
        /// EMail settings
        /// </summary>
        Email = 2,

        /// <summary>
        /// Cms Settings
        /// </summary>
        Cms = 3
    }

    public enum DisputeStatusName
    {
        Submitted = 1,
        NeedsUpdate = 2
    }

    public enum EmailStatus
    {
        UnSent = 0,
        Sent = 1,
        Pending = 2,
        Error = 3
    }

    public enum EmailMessageBodyType
    {
        Plain = 0,
        Html,
        Both
    }

    public enum ParticipantType
    {
        Applicant = 0,
        Respondent = 1,
        Agent = 2
    }

    public enum SearchSortField
    {
        Submitted = 1,
        Created = 2,
        Modified = 3,
        Status = 4
    }

    public enum SortDir
    {
        ASC = 0,
        DESC
    }

    public enum PaymentMethod
    {
        Online = 1,
        Office = 2,
        FeeWaiver = 3
    }

    public enum PaymentStatus
    {
        Pending = 1,
        ApprovedOrPaid = 2,
        Rejected = 3,
        Cancelled = 4
    }

    public enum PaymentVerified
    {
        NotChecked = 0,
        Checked = 1,
        Error = 2
    }

    public enum PaymentProvider
    {
        Bambora = 1
    }

    public enum AttachmentType
    {
        Dispute = 1,
        Common = 2
    }
}
