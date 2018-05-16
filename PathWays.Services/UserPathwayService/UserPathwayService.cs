using System.Collections.Generic;
using System.Threading.Tasks;
using PathWays.Data.Model;
using PathWays.Data.Repositories.UnitOfWork;

namespace PathWays.Services.UserPathwayService
{
    public class UserPathwayService : IUserPathwayService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserPathwayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserPathway> CreateAsync(UserPathway userPathway)
        {
            userPathway.IsDeleted = false;

            var result = await _unitOfWork.UserPathwayRepository.InsertAsync(userPathway);
            await _unitOfWork.Complete();
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userPathway = await _unitOfWork.UserPathwayRepository.GetByIdAsync(id);
            if (userPathway != null)
            {
                userPathway.IsDeleted = true;
                _unitOfWork.UserPathwayRepository.Attach(userPathway);
                var result = await _unitOfWork.Complete();

                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public async Task<UserPathway> UpdateAsync(UserPathway userPathway)
        {
            _unitOfWork.UserPathwayRepository.Attach(userPathway);
            var result = await _unitOfWork.Complete();

            if (result == 1)
            {
                return userPathway;
            }

            return null;
        }

        public async Task<UserPathway> GetNoTrackingAsync(int id)
        {
            var result = await _unitOfWork.UserPathwayRepository.GetNoTrackingByIdAsync(x => x.UserPathwayId == id);
            return result;
        }

        public async Task<UserPathway> GetByIdAsync(int id)
        {
            var userPathway = await _unitOfWork.UserPathwayRepository.GetByIdAsync(id);
            return userPathway;
        }

        public async Task<ICollection<UserPathway>> GetAllAsync()
        {
            var userPathways = await _unitOfWork.UserPathwayRepository.GetAllAsync();
            return userPathways;
        }
    }
}
