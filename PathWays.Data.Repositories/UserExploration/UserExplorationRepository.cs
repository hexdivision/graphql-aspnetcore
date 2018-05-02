using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.UserExploration
{
    public class UserExplorationRepository : PathWaysRepository<Model.UserExploration>, IUserExplorationRepository
    {
        public UserExplorationRepository(PathWaysContext context)
            : base(context)
        {
        }

        public async Task<List<string>> GetAccessCodes(char firstLetter)
        {
            var accessCodes = await Context.UserExplorations
                .Where(p => p.AccessCode.StartsWith(firstLetter))
                .Select(p => p.AccessCode)
                .ToListAsync();

            return accessCodes;
        }

        public async Task<Model.UserExploration> GetByAccessCode(string accessCode)
        {
            var userExploration = await Context.UserExplorations.FirstOrDefaultAsync(p => p.AccessCode.Equals(accessCode));
            return userExploration;
        }

        public async Task<List<Model.UserExploration>> GetAllWithTokens()
        {
            var userExploration = await Context.UserExplorations.Include(u => u.UserExplorationTokens).ToListAsync();
            return userExploration;
        }
    }
}
