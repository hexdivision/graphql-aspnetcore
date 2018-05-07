using System.Collections.Generic;
using System.Threading.Tasks;
using PathWays.Data.Model;

namespace PathWays.Services.UserReportService
{
    public interface IUserReportService
    {
        Task<UserReport> GetUserReportAsync(int id);

        Task<ICollection<UserReport>> GetUserReports();

        Task<UserReport> CreateAsync(UserReport userReport);

        Task<bool> DeleteAsync(int id);

        Task<UserReport> UpdateAsync(UserReport userReport);

        Task<UserReport> GetNoTrackingAsync(int id);
    }
}
