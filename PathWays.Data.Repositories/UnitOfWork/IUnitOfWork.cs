using System.Threading.Tasks;
using PathWays.Data.Repositories.Domain;
using PathWays.Data.Repositories.ExcludeWord;
using PathWays.Data.Repositories.Organization;
using PathWays.Data.Repositories.Pathway;
using PathWays.Data.Repositories.Role;
using PathWays.Data.Repositories.SystemSettings;
using PathWays.Data.Repositories.Token;
using PathWays.Data.Repositories.User;
using PathWays.Data.Repositories.UserExploration;
using PathWays.Data.Repositories.UserExplorationToken;
using PathWays.Data.Repositories.UserPathway;
using PathWays.Data.Repositories.UserReport;
using PathWays.Data.Repositories.UserStep;

namespace PathWays.Data.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        ITokenRepository TokenRepository { get; }

        ISystemUserRepository SystemUserRepository { get; }

        IRoleRepository RoleRepository { get; }

        ISystemSettingsRepository SystemSettingsRepository { get; }

        IUserExplorationRepository UserExplorationRepository { get; }

        IUserExplorationTokenRepository UserExplorationTokenRepository { get; }

        IExcludeWordRepository ExcludeWordRepository { get; }

        IUserReportRepository UserReportRepository { get; }

        IReportItemRepository ReportItemRepository { get; }

        IUserPathwayRepository UserPathwayRepository { get; }

        IUserStepRepository UserStepRepository { get; }

        IPathwayRepository PathwayRepository { get; }

        IDomainRepository DomainRepository { get; }

        IOrganizationRepository OrganizationRepository { get; }

        Task<int> Complete();
    }
}
