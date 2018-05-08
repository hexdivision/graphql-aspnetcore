using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.UserReport
{
    public class ReportItemRepository : PathWaysRepository<ReportItem>, IReportItemRepository
    {
        public ReportItemRepository(PathWaysContext context)
            : base(context)
        {
        }
    }
}
