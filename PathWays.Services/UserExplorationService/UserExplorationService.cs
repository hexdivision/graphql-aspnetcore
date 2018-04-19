using System.Collections.Generic;
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

        public UserExploration CreateUserExploration(UserExploration userExploration)
        {
            throw new System.NotImplementedException();
        }

        public UserExploration GetUserExploration(int explorationId)
        {
            throw new System.NotImplementedException();
        }

        public List<UserExploration> GetUserExplorations()
        {
            throw new System.NotImplementedException();
        }
    }
}
