using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PathWays.Data.Repositories.UnitOfWork;

namespace PathWays.Services.ReportItem
{
    public class ReportItemService : IReportItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Data.Model.ReportItem> CreateAsync(Data.Model.ReportItem reportItem)
        {
            reportItem.IsDeleted = false;
            reportItem.CreatedDate = DateTime.Now;

            var result = await _unitOfWork.ReportItemRepository.InsertAsync(reportItem);
            await _unitOfWork.Complete();
            return result;
        }

        public async Task<Data.Model.ReportItem> GetByIdAsync(int id)
        {
            var reportItem = await _unitOfWork.ReportItemRepository.GetByIdAsync(id);
            return reportItem;
        }

        public async Task<Data.Model.ReportItem> GetNoTrackingByIdAsync(int id)
        {
            var result = await _unitOfWork.ReportItemRepository.GetNoTrackingByIdAsync(x => x.ReportItemId == id);
            return result;
        }

        public async Task<ICollection<Data.Model.ReportItem>> GetAllAsync()
        {
            var reportItems = await _unitOfWork.ReportItemRepository.GetAllAsync();
            return reportItems;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reportItem = await _unitOfWork.ReportItemRepository.GetByIdAsync(id);
            if (reportItem != null)
            {
                reportItem.IsDeleted = true;
                _unitOfWork.ReportItemRepository.Attach(reportItem);
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

        public async Task<Data.Model.ReportItem> UpdateAsync(Data.Model.ReportItem reportItem)
        {
            _unitOfWork.ReportItemRepository.Attach(reportItem);
            var result = await _unitOfWork.Complete();

            if (result == 1)
            {
                return reportItem;
            }

            return null;
        }
    }
}
