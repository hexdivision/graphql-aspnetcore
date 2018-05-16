using System.Collections.Generic;
using System.Threading.Tasks;
using PathWays.Data.Model;

namespace PathWays.Services.UserPathwayService
{
    public interface IUserPathwayService
    {
        Task<UserPathway> CreateAsync(UserPathway userPathway);

        Task<bool> DeleteAsync(int id);

        Task<UserPathway> UpdateAsync(UserPathway userPathway);

        Task<UserPathway> GetNoTrackingAsync(int id);

        Task<UserPathway> GetByIdAsync(int id);

        Task<ICollection<UserPathway>> GetAllAsync();
    }
}
