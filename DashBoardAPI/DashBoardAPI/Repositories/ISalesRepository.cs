using DashBoardAPI.Models;

namespace DashBoardAPI.Repositories
{
    public interface ISalesRepository
    {
        Task<List<SalesDatum>> GetAllWeekSalesData();
        Task<ModelData> GetWeekTopSoldModelWithAmount();
        Task<ModelData> GetWeekLeastSoldModelWithAmount();
        Task<List<SalesRankedData>> GetTopRankModelsSalesData();
        Task<List<SalesRankedData>> GetLeastRankModelsSalesData();
        Task<List<ModelData>> GetSalesDataOfEachProductAcrossAllCities();
        Task<decimal> TotalWeekSalesAcrossAllModelsAndCities();
    }
}
