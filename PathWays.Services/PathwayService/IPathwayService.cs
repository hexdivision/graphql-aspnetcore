using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PathWays.Data.Model;

namespace PathWays.Services.PathwayService
{
    public interface IPathwayService
    {
        Task<Pathway> CreateAsync(Pathway pathway);

        Task<bool> IsDomainExists(int domainId);
    }
}
