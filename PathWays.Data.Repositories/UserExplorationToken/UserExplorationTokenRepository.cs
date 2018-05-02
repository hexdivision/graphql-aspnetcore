using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.UserExplorationToken
{
    public class UserExplorationTokenRepository : PathWaysRepository<Model.UserExplorationToken>, IUserExplorationTokenRepository
    {
        public UserExplorationTokenRepository(PathWaysContext context)
            : base(context)
        {
        }
    }
}
