using System.Collections.Generic;
using System.Threading.Tasks;
using PathWays.Data.Model;

namespace PathWays.Services.UserExplorationService
{
    public interface IUserExplorationService
    {
        Task<UserExploration> CreateUserExploration(UserExploration userExploration);

        Task<UserExploration> GetUserExploration(int explorationId);

        Task<UserExploration> GetUserExploration(string accessCode);

        Task<ICollection<UserExploration>> GetUserExplorations();

        Task<bool> DeleteUserExploration(int explorationId);

        Task<UserExploration> UpdateUserExploration(UserExploration userExploration);
    }
}
