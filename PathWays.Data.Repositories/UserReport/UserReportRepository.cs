using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.UserReport
{
    public class UserReportRepository : PathWaysRepository<Model.UserReport>, IUserReportRepository
    {
        public UserReportRepository(PathWaysContext context)
            : base(context)
        {
        }
    }
}
