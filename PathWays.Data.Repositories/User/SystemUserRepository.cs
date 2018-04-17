using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.User
{
    public class SystemUserRepository : PathWaysRepository<SystemUser>, ISystemUserRepository
    {
        public SystemUserRepository(PathWaysContext context)
            : base(context)
        {
        }

        public SystemUser GetUser(string username, string password)
        {
            var user = Context.SystemUsers.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                return user;
            }

            return null;
        }

        public async Task<SystemUser> GetUserWithFullInfo(int id)
        {
            var user = await Context.SystemUsers.Include(u => u.SystemUserRole).SingleOrDefaultAsync(s => s.SystemUserId == id);
            return user;
        }

        public async Task<DateTime?> GetLastModifiedDate(int userId)
        {
            var lastModifiedDate = await Context.SystemUsers
                .Where(d => d.SystemUserId == userId)
                .Select(d => d.ModifiedDate).ToListAsync();

            return lastModifiedDate.FirstOrDefault();
        }

        public async Task<List<SystemUser>> GetInternalUsersWithRolesAsync()
        {
            var internalUsers = await Context.SystemUsers
                .Where(u => u.AdminAccess && u.SystemUserRoleId == 1)
                .ToListAsync();

            return internalUsers;
        }
    }
}
