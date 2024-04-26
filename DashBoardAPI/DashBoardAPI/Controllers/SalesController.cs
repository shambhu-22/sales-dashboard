using DashBoardAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DashBoardAPI.Controllers
{
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository salesRepository;
        public SalesController(ISalesRepository _salesRepository)
        {
            salesRepository = _salesRepository;
        }
        /// <summary>
        /// Get All sales data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/Get", Name = "GetSalesData")]
        public async Task<IActionResult> GetSalesData()
        {
            var salesData = await salesRepository.GetAllWeekSalesData();
            return Ok(salesData);
        }
        /// <summary>
        /// Get top sold model with it's name
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/GetWeekTopSoldModelWithAmountAcrossCities")]
        public async Task<IActionResult> GetWeekTopSoldModelWithAmountAcrossCities()
        {
            var salesData = await salesRepository.GetWeekTopSoldModelWithAmount();
            return Ok(salesData);
        }

        /// <summary>
        /// Get least sold model with it's name
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/GetWeekLeastSoldModelWithAmountAcrossCities")]
        public async Task<IActionResult> GetWeekLeastSoldModelWithAmountAcrossCities()
        {
            var salesData = await salesRepository.GetWeekLeastSoldModelWithAmount();
            return Ok(salesData);
        }

        /// <summary>
        /// Get top sold models data city wise
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/GetTopRankModelsSalesDataResult")]
        public async Task<IActionResult> GetTopRankModelsSalesDataResult()
        {
            var salesData = await salesRepository.GetTopRankModelsSalesData();
            return Ok(salesData);
        }

        /// <summary>
        /// Get least sold models data city wise
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/GetLeastRankModelsSalesDataResults")]
        public async Task<IActionResult> GetLeastRankModelsSalesDataResults()
        {
            var salesData = await salesRepository.GetLeastRankModelsSalesData();
            return Ok(salesData);
        }

        /// <summary>
        /// Get total sold sales amount across all models and cities
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/GetTotalWeekSalesAcrossAllModelsAndCities")]
        public async Task<IActionResult> GetTotalWeekSalesAcrossAllModelsAndCities()
        {
            var totalSalesAmount = await salesRepository.TotalWeekSalesAcrossAllModelsAndCities();
            return Ok(totalSalesAmount);
        }

        /// <summary>
        /// Get sales data for each product across all cities for bar chart
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/GetSalesDataOfEachProductAcrossAllCitiesList")]
        public async Task<IActionResult> GetSalesDataOfEachProductAcrossAllCitiesList()
        {
            var salesData = await salesRepository.GetSalesDataOfEachProductAcrossAllCities();
            return Ok(salesData);
        }
    }
}
