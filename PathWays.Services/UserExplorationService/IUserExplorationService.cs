using System.Collections.Generic;
using System.Threading.Tasks;
using PathWays.Data.Model;

namespace PathWays.Services.UserExplorationService
{
    public interface IUserExplorationService
    {
        Task<UserExploration> CreateUserExploration(UserExploration userExploration);

        Task<UserExploration> GetUserExploration(int explorationId);

        Task<ICollection<UserExploration>> GetUserExplorations();
    }
}
