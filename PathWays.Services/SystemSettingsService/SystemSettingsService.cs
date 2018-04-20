using System.Collections.Generic;
using System.Threading.Tasks;
using PathWays.Data.Model;
using PathWays.Data.Repositories.UnitOfWork;

namespace PathWays.Services.SystemSettingsService
{
    public class SystemSettingsService : ISystemSettingsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SystemSettingsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SystemSettings> AddSettings(SystemSettings systemSettings)
        {
            var result = await _unitOfWork.SystemSettingsRepository.InsertAsync(systemSettings);
            await _unitOfWork.Complete();

            return result;
        }

        public async Task<ICollection<SystemSettings>> GetListAsync()
        {
            var setting = await _unitOfWork.SystemSettingsRepository.GetAllAsync();
            return setting;
        }

        public async Task<SystemSettings> GetSetting(string key)
        {
            var setting = await _unitOfWork.SystemSettingsRepository.GetSetting(key);
            return setting;
        }
    }
}
