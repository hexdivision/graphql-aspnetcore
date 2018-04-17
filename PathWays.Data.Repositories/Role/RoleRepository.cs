using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.Role
{
    public class RoleRepository : PathWaysRepository<Data.Model.SystemUserRole>, IRoleRepository
    {
        public RoleRepository(PathWaysContext context)
            : base(context)
        {
        }
    }
}
