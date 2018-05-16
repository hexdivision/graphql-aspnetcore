using System.Collections.Generic;
using System.Threading.Tasks;
using PathWays.Data.Model;

namespace PathWays.Services.UserStepService
{
    public interface IUserStepService
    {
        Task<UserStep> CreateAsync(UserStep userStep);

        Task<bool> DeleteAsync(int id);

        Task<UserStep> UpdateAsync(UserStep userStep);

        Task<UserStep> GetNoTrackingAsync(int id);

        Task<UserStep> GetByIdAsync(int id);

        Task<ICollection<UserStep>> GetAllAsync();
    }
}