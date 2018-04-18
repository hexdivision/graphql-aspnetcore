using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.UserExploration
{
    public class UserExplorationRepository : PathWaysRepository<Model.UserExploration>, IUserExplorationRepository
    {
        protected UserExplorationRepository(PathWaysContext context)
            : base(context)
        {
        }
    }
}
