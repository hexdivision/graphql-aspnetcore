using System.Threading.Tasks;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.SystemSettings
{
    public interface ISystemSettingsRepository : IRepository<Model.SystemSettings>
    {
        Task<Model.SystemSettings> GetSetting(string key);
    }
}
