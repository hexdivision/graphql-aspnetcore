using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.User
{
    public interface ISystemUserRepository : IRepository<SystemUser>
    {
        SystemUser GetUser(string username, string password);

        Task<SystemUser> GetUserWithFullInfo(int id);

        Task<DateTime?> GetLastModifiedDate(int userId);

        Task<List<SystemUser>> GetInternalUsersWithRolesAsync();
    }
}
