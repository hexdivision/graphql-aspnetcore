﻿using System.Threading.Tasks;
using PathWays.Data.Repositories.ExcludeWord;
using PathWays.Data.Repositories.Role;
using PathWays.Data.Repositories.SystemSettings;
using PathWays.Data.Repositories.Token;
using PathWays.Data.Repositories.User;
using PathWays.Data.Repositories.UserExploration;
using PathWays.Data.Repositories.UserExplorationToken;
using PathWays.Data.Repositories.UserReport;

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

        Task<int> Complete();
    }
}
