using System;
using System.Collections.Generic;
using System.Text;
using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.Pathway
{
    public class PathwayRepository : PathWaysRepository<Model.Pathway>, IPathwayRepository
    {
        public PathwayRepository(PathWaysContext context)
            : base(context)
        {
        }
    }
}
