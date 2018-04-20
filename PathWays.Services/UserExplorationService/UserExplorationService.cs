using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PathWays.Data.Model;
using PathWays.Data.Repositories.UnitOfWork;

namespace PathWays.Services.UserExplorationService
{
    public class UserExplorationService : IUserExplorationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserExplorationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserExploration> CreateUserExploration(UserExploration userExploration)
        {
            var result = await _unitOfWork.UserExplorationRepository.InsertAsync(userExploration);
            await _unitOfWork.Complete();

            return result;
        }

        public async Task<UserExploration> GetUserExploration(int explorationId)
        {
            var result = await _unitOfWork.UserExplorationRepository.GetByIdAsync(explorationId);
            return result;
        }

        public async Task<ICollection<UserExploration>> GetUserExplorations()
        {
            var result = await _unitOfWork.UserExplorationRepository.GetAllAsync();
            return result;
        }
    }
}
