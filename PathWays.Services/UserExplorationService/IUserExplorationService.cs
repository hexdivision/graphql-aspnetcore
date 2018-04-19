using System.Collections.Generic;
using PathWays.Data.Model;

namespace PathWays.Services.UserExplorationService
{
    public interface IUserExplorationService
    {
        UserExploration CreateUserExploration(UserExploration userExploration);

        UserExploration GetUserExploration(int explorationId);

        List<UserExploration> GetUserExplorations();
    }
}
