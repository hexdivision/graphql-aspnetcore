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

        Task<Pathway> GetNoTrackingPathway(int pathwayId);

        Task<Pathway> UpdatePathway(Pathway pathway);

        Task<bool> DeletePathway(int pathwayId);

        Task<Pathway> GetPathway(int pathwayId);
    }
}
