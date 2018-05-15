using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PathWays.Data.Model;
using PathWays.Data.Repositories.UnitOfWork;

namespace PathWays.Services.PathwayService
{
    public class PathwayService : IPathwayService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PathwayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Pathway> CreateAsync(Pathway pathway)
        {
            pathway.CreatedDate = DateTime.Now;
            pathway.IsActive = true;
            pathway.IsDeleted = false;

            var result = await _unitOfWork.PathwayRepository.InsertAsync(pathway);
            await _unitOfWork.Complete();
            return result;
        }

        public async Task<bool> IsDomainExists(int domainId)
        {
            var domain = await _unitOfWork.DomainRepository.GetByIdAsync(domainId);
            return domain != null;
        }
    }
}
