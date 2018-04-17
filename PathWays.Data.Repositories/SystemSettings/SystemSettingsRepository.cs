using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.SystemSettings
{
    public class SystemSettingsRepository : PathWaysRepository<Model.SystemSettings>, ISystemSettingsRepository
    {
        public SystemSettingsRepository(PathWaysContext context)
            : base(context)
        {
        }

        public async Task<Model.SystemSettings> GetSetting(string key)
        {
            var setting = await Context.SystemSettings.SingleOrDefaultAsync(s => s.Key == key);
            return setting;
        }
    }
}
