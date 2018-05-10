using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PathWays.Data.Model;
using PathWays.Data.Repositories.UnitOfWork;

namespace PathWays.Services.UserStepService
{
    public class UserStepService : IUserStepService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserStepService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserStep> CreateAsync(UserStep userStep)
        {
            userStep.IsDeleted = false;

            var result = await _unitOfWork.UserStepRepository.InsertAsync(userStep);
            await _unitOfWork.Complete();
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userStep = await _unitOfWork.UserStepRepository.GetByIdAsync(id);
            if (userStep != null)
            {
                userStep.IsDeleted = true;
                _unitOfWork.UserStepRepository.Attach(userStep);
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

        public async Task<UserStep> UpdateAsync(UserStep userStep)
        {
            _unitOfWork.UserStepRepository.Attach(userStep);
            var result = await _unitOfWork.Complete();

            if (result == 1)
            {
                return userStep;
            }

            return null;
        }

        public async Task<UserStep> GetNoTrackingAsync(int id)
        {
            var result = await _unitOfWork.UserStepRepository.GetNoTrackingByIdAsync(x => x.UserStepId == id);
            return result;
        }

        public async Task<UserStep> GetByIdAsync(int id)
        {
            var userStep = await _unitOfWork.UserStepRepository.GetByIdAsync(id);
            return userStep;
        }

        public async Task<ICollection<UserStep>> GetAllAsync()
        {
            var userSteps = await _unitOfWork.UserStepRepository.GetAllAsync();
            return userSteps;
        }
    }
}
