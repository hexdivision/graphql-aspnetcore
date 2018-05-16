using System;
using System.Collections.Generic;
using System.Text;
using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.Domain
{
    public class DomainRepository : PathWaysRepository<Model.Domain>, IDomainRepository
    {
        public DomainRepository(PathWaysContext context)
            : base(context)
        {
        }
    }
}
