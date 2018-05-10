using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.UserStep
{
    public class UserStepRepository : PathWaysRepository<Model.UserStep>, IUserStepRepository
    {
        public UserStepRepository(PathWaysContext context)
            : base(context)
        {
        }
    }
}
