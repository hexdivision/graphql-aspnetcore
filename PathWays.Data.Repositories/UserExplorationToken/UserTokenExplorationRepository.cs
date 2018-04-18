using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.UserExplorationToken
{
    public class UserTokenExplorationRepository : PathWaysRepository<Model.UserExplorationToken>, IUserExplorationTokenRepository
    {
        protected UserTokenExplorationRepository(PathWaysContext context)
            : base(context)
        {
        }
    }
}
