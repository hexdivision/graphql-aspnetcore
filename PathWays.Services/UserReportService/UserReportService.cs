using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PathWays.Data.Model;
using PathWays.Data.Repositories.UnitOfWork;

namespace PathWays.Services.UserReportService
{
    public class UserReportService : IUserReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserReport> GetUserReportAsync(int id)
        {
            var userReport = await _unitOfWork.UserReportRepository.GetByIdAsync(id);
            return userReport;
        }

        public async Task<ICollection<UserReport>> GetUserReports()
        {
            var userReports = await _unitOfWork.UserReportRepository.GetAllAsync();
            return userReports;
        }

        public async Task<UserReport> CreateAsync(UserReport userReport)
        {
            userReport.IsDeleted = false;
            userReport.CreatedDate = DateTime.Now;

            var result = await _unitOfWork.UserReportRepository.InsertAsync(userReport);
            await _unitOfWork.Complete();
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userReport = await _unitOfWork.UserReportRepository.GetByIdAsync(id);
            if (userReport != null)
            {
                userReport.IsDeleted = true;
                _unitOfWork.UserReportRepository.Attach(userReport);
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

        public async Task<UserReport> UpdateAsync(UserReport userReport)
        {
            _unitOfWork.UserReportRepository.Attach(userReport);
            var result = await _unitOfWork.Complete();

            if (result == 1)
            {
                return userReport;
            }

            return null;
        }

        public async Task<UserReport> GetNoTrackingAsync(int id)
        {
            var result = await _unitOfWork.UserReportRepository.GetNoTrackingByIdAsync(x => x.UserReportId == id);
            return result;
        }
    }
}
