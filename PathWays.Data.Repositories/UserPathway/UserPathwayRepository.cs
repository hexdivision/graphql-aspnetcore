using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.UserPathway
{
    public class UserPathwayRepository : PathWaysRepository<Model.UserPathway>, IUserPathwayRepository
    {
        public UserPathwayRepository(PathWaysContext context)
            : base(context)
        {
        }
    }
}
