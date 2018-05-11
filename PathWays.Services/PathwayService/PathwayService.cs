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

        public async Task<bool> DeletePathway(int pathwayId)
        {
            var pathway = await _unitOfWork.PathwayRepository.GetByIdAsync(pathwayId);
            if (pathway != null)
            {
                pathway.IsDeleted = true;
                _unitOfWork.PathwayRepository.Attach(pathway);
                var result = await _unitOfWork.Complete();

                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public async Task<Pathway> GetNoTrackingPathway(int pathwayId)
        {
            var result = await _unitOfWork.PathwayRepository.GetNoTrackingByIdAsync(x => x.PathwayId == pathwayId);
            return result;
        }

        public async Task<Pathway> GetPathway(int pathwayId)
        {
            var result = await _unitOfWork.PathwayRepository.GetByIdAsync(pathwayId);
            return result;
        }

        public async Task<Pathway> UpdatePathway(Pathway pathway)
        {
            _unitOfWork.PathwayRepository.Attach(pathway);
            var result = await _unitOfWork.Complete();

            if (result == 1)
            {
                return pathway;
            }

            return null;
        }
    }
}
