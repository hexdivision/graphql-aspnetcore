using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.ExcludeWord
{
    public class ExcludeWordRepository : PathWaysRepository<AccessCodeExcludeWord>, IExcludeWordRepository
    {
        protected ExcludeWordRepository(PathWaysContext context)
            : base(context)
        {
        }
    }
}
