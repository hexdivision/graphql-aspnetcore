using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.Organization
{
    public class OrganizationRepository : PathWaysRepository<Model.Organization>, IOrganizationRepository
    {
        public OrganizationRepository(PathWaysContext context)
            : base(context)
        {
        }
    }
}
