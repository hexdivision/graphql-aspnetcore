using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PathWays.Data.Model;
using PathWays.Data.Repositories.ExcludeWord;
using PathWays.Data.Repositories.Role;
using PathWays.Data.Repositories.SystemSettings;
using PathWays.Data.Repositories.Token;
using PathWays.Data.Repositories.User;
using PathWays.Data.Repositories.UserExploration;
using PathWays.Data.Repositories.UserExplorationToken;

namespace PathWays.Data.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PathWaysContext _context;
        private ITokenRepository tokenRepository = null;
        private ISystemUserRepository systemUserRepository = null;
        private IRoleRepository roleRepository = null;
        private ISystemSettingsRepository systemSettingsRepository = null;
        private IUserExplorationRepository userExplorationRepository = null;
        private IUserExplorationTokenRepository userExplorationTokenRepository = null;
        private IExcludeWordRepository excludeWordRepository = null;

        public UnitOfWork(PathWaysContext context)
        {
            _context = context;
        }

        public ITokenRepository TokenRepository => tokenRepository ?? new TokenRepository(_context);

        public ISystemUserRepository SystemUserRepository => systemUserRepository ?? new SystemUserRepository(_context);

        public IRoleRepository RoleRepository => roleRepository ?? new RoleRepository(_context);

        public ISystemSettingsRepository SystemSettingsRepository => systemSettingsRepository ?? new SystemSettingsRepository(_context);

        public IUserExplorationRepository UserExplorationRepository => userExplorationRepository ?? new UserExplorationRepository(_context);

        public IUserExplorationTokenRepository UserExplorationTokenRepository => userExplorationTokenRepository ?? new UserExplorationTokenRepository(_context);

        public IExcludeWordRepository ExcludeWordRepository => excludeWordRepository ?? new ExcludeWordRepository(_context);

        public async Task<int> Complete()
        {
            using (var scope = _context.Database.BeginTransaction())
            {
                try
                {
                    var res = await _context.SaveChangesAsync();
                    scope.Commit();
                    return res;
                }
                catch (SqlException ex)
                {
                    scope.Rollback();
                    Debug.WriteLine(ex.Message);
                    return await System.Threading.Tasks.Task.FromResult(ex.Number);
                }
                catch (InvalidOperationException ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}
