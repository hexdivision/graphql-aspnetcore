using System.Collections.Generic;
using System.Threading.Tasks;

namespace PathWays.Services.ReportItem
{
    public interface IReportItemService
    {
        Task<Data.Model.ReportItem> CreateAsync(Data.Model.ReportItem reportItem);

        Task<Data.Model.ReportItem> GetByIdAsync(int id);

        Task<Data.Model.ReportItem> GetNoTrackingByIdAsync(int id);

        Task<ICollection<Data.Model.ReportItem>> GetAllAsync();

        Task<bool> DeleteAsync(int id);

        Task<Data.Model.ReportItem> UpdateAsync(Data.Model.ReportItem reportItem);
    }
}
