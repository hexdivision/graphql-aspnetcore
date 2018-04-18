using System.Collections.Generic;
using System.Threading.Tasks;
using PathWays.Data.Model;

namespace PathWays.Services.SystemSettingsService
{
    public interface ISystemSettingsService
    {
        Task<SystemSettings> GetSetting(string key);

        Task<ICollection<SystemSettings>> GetListAsync();

        Task<SystemSettings> AddSettings(SystemSettings systemSettings);
    }
}