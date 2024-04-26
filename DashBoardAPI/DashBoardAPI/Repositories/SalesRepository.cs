using DashBoardAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DashBoardAPI.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        ModelDataContext modelDataContext;

        public SalesRepository(ModelDataContext _modelDataContext)
        {
            modelDataContext = _modelDataContext;
        }

        public async Task<List<SalesDatum>> GetAllWeekSalesData()
        {
            var salesData = await modelDataContext.SalesData.ToListAsync();
            return salesData;
        }
        /// <summary>
        /// Most sold model across all cities
        /// </summary>
        /// <returns></returns>
        public async Task<ModelData> GetWeekTopSoldModelWithAmount()
        {
            var dataObj = await modelDataContext.TotalSumResults.FromSqlRaw("EXEC sp_GetTopSoldModelData").ToListAsync();
            ModelData modelData = new ModelData();
            if(dataObj != null) {
                modelData = dataObj.FirstOrDefault();
            }
            return modelData;
        }
        /// <summary>
        /// Least sold model across all cities
        /// </summary>
        /// <returns></returns>
        public async Task<ModelData> GetWeekLeastSoldModelWithAmount()
        {
            var dataObj = await modelDataContext.TotalSumResults.FromSqlRaw("EXEC sp_GetLeastSoldModelData").ToListAsync();
            ModelData modelData = new ModelData();
            if (dataObj != null)
            {
                modelData = dataObj.FirstOrDefault();
            }
            return modelData;
        }
        /// <summary>
        /// City wise least sold model
        /// </summary>
        /// <returns></returns>
        public async Task<List<SalesRankedData>> GetLeastRankModelsSalesData()
        {
            var rankedSalesData = await GetRankedSalesData();
            if(rankedSalesData != null)
            {
                var leastRank = rankedSalesData.OrderBy(x => x.Sales_rank).FirstOrDefault().Sales_rank;
                if(leastRank != null)
                {
                    var leastRankData = rankedSalesData.Where(x => x.Sales_rank == leastRank).ToList();
                    if (leastRankData != null)
                    {
                        return leastRankData;
                    }
                }
                return null;
            }
            return null;
        }
        /// <summary>
        /// City wise top sold model
        /// </summary>
        /// <returns></returns>
        public async Task<List<SalesRankedData>> GetTopRankModelsSalesData()
        {
            var rankedSalesData = await GetRankedSalesData();
            if (rankedSalesData != null)
            {
                var topRankData = rankedSalesData.Where(x => x.Sales_rank == 1).ToList();
                if (topRankData != null)
                {
                    return topRankData;
                }
                return null;
            }
            return null;
        }
        /// <summary>
        /// Total sales of the week across all cities and products
        /// </summary>
        /// <returns></returns>
        public async Task<decimal> TotalWeekSalesAcrossAllModelsAndCities()
        {
            var allSalesData = await GetAllWeekSalesData();
            if(allSalesData != null)
            {
                var totalSum = allSalesData.Select(x => x.Date11062023 + x.Date12062023 + x.Date13062023 
                                + x.Date14062023 + x.Date15062023 + x.Date16062023 + x.Date17062023).Sum();
                return totalSum ?? 0;
            }
            return 0;
        }
        /// <summary>
        /// Sales data by products across all cities for bar chart
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<ModelData>> GetSalesDataOfEachProductAcrossAllCities()
        {
            var totalSalesDataForEachproduct = await modelDataContext.TotalSumResults.FromSqlRaw("EXEC sp_SalesByProductAcrossCities").ToListAsync();
            if (totalSalesDataForEachproduct != null)
            {
                return totalSalesDataForEachproduct;
            }
            return null;
        }

        private async Task<List<SalesRankedData>> GetRankedSalesData()
        {
            var rankedSalesData = await modelDataContext.RankedSalesResults.FromSqlRaw("EXEC sp_RankedSalesData").ToListAsync();
            if (rankedSalesData != null)
            {
                return rankedSalesData;
            }
            return null;
        }
    }
}
