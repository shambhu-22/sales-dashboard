using DashBoardAPI.Controllers;
using DashBoardAPI.Models;
using DashBoardAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardAPI.Tests
{
    public class SalesControllerTest
    {
        private readonly Mock<ISalesRepository> _mockRepo;
        private readonly SalesController _controller;

        public SalesControllerTest()
        {
            _mockRepo = new Mock<ISalesRepository>();
            _controller = new SalesController(_mockRepo.Object);
        }

        [Fact]
        public void GetSalesData_Returns_TaskIActionResultData()
        {
            var result = _controller.GetSalesData();
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public async void GetSalesData_Returns_ListData()
        {
            // Arrange
            var expectedData = FakeDb.salesData;
            _mockRepo.Setup(p => p.GetAllWeekSalesData())
                .ReturnsAsync(expectedData);
            // Act
            var result = await _controller.GetSalesData() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedData, result.Value);
        }

        [Fact]
        public async void GetWeekTopSoldModelWithAmount_Returns_ModelData()
        {
            // Arrange
            var expectedData = FakeDb.modelData; // assuming expectedData is top sold model
            _mockRepo.Setup(p => p.GetWeekTopSoldModelWithAmount())
                .ReturnsAsync(expectedData);
            // Act
            var result = await _controller.GetWeekTopSoldModelWithAmountAcrossCities() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ModelData>(result.Value);
            Assert.Equal(expectedData, result.Value);
        }

        [Fact]
        public async void GetWeekLeastSoldModelWithAmountAcrossCities_Returns_ModelData()
        {
            // Arrange
            var expectedData = FakeDb.modelData; // assuming expectedData is least sold model
            _mockRepo.Setup(p => p.GetWeekLeastSoldModelWithAmount())
                .ReturnsAsync(expectedData);
            // Act
            var result = await _controller.GetWeekLeastSoldModelWithAmountAcrossCities() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ModelData>(result.Value);
            Assert.Equal(expectedData, result.Value);
        }
        
        [Fact]
        public async void GetTopRankModelsSalesDataResult_Returns_ModelData()
        {
            // Arrange
            var expectedData = FakeDb.rankedData; // assuming expectedData is most sold models data
            _mockRepo.Setup(p => p.GetTopRankModelsSalesData())
                .ReturnsAsync(expectedData);
            // Act
            var result = await _controller.GetTopRankModelsSalesDataResult() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<SalesRankedData>>(result.Value);
            Assert.Equal(expectedData, result.Value);
        }
        
        [Fact]
        public async void GetLeastRankModelsSalesDataResults_Returns_ModelData()
        {
            // Arrange
            var expectedData = FakeDb.rankedData; // assuming expectedData is least sold models data
            _mockRepo.Setup(p => p.GetLeastRankModelsSalesData())
                .ReturnsAsync(expectedData);
            // Act
            var result = await _controller.GetLeastRankModelsSalesDataResults() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<SalesRankedData>>(result.Value);
            Assert.Equal(expectedData, result.Value);
        }
        
        [Fact]
        public async void GetTotalWeekSalesAcrossAllModelsAndCities_Returns_ModelData()
        {
            // Arrange
            var expectedData = (decimal)323434354.98; // assuming this is total sales data
            _mockRepo.Setup(p => p.TotalWeekSalesAcrossAllModelsAndCities())
                .ReturnsAsync(expectedData);
            // Act
            var result = await _controller.GetTotalWeekSalesAcrossAllModelsAndCities() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<decimal>(result.Value);
            Assert.Equal(expectedData, result.Value);
        }

        [Fact]
        public async void GetSalesDataOfEachProductAcrossAllCitiesList_Returns_ModelData()
        {
            // Arrange
            var expectedData = FakeDb.modelDataList; // assuming this is total sales data
            _mockRepo.Setup(p => p.GetSalesDataOfEachProductAcrossAllCities())
                .ReturnsAsync(expectedData);
            // Act
            var result = await _controller.GetSalesDataOfEachProductAcrossAllCitiesList() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<ModelData>>(result.Value);
            Assert.Equal(expectedData, result.Value);
        }
    }

    public static class FakeDb
    {
        public static List<SalesDatum> salesData = new List<SalesDatum>()
        {
            new SalesDatum(){
                    Product = "VA1",
                    Date11062023 = 112000,
                    Date12062023 = 240000,
                    Date13062023 = 160000,
                    Date14062023 = 176000,
                    Date15062023 = 128000,
                    Date16062023 = 160000,
                    Date17062023 = 352000,
                    City = "bengaluru",
                    Id = 1
                },
            new SalesDatum()
                {
                    Product = "VA2",
                    Date11062023 = 112000,
                    Date12062023 = 240000,
                    Date13062023 = 160000,
                    Date14062023 = 176000,
                    Date15062023 = 128000,
                    Date16062023 = 160000,
                    Date17062023 = 352000,
                    City = "mumbai",
                    Id = 2
                },
            new SalesDatum()
                {
                    Product = "VA3",
                    Date11062023 = 112000,
                    Date12062023 = 240000,
                    Date13062023 = 160000,
                    Date14062023 = 176000,
                    Date15062023 = 128000,
                    Date16062023 = 160000,
                    Date17062023 = 352000,
                    City = "delhi",
                    Id = 3
                }
        };

        public static List<SalesRankedData> rankedData = new List<SalesRankedData>() {
            new SalesRankedData
            {
                 City = "bengaluru",
                 Id = 1,
                 Product = "VA2",
                 Week_Total = 1232323243,
                 Sales_rank = 1
            },
            new SalesRankedData
            {
                 City = "mumbai",
                 Id = 1,
                 Product = "VA1",
                 Week_Total = 1223243,
                 Sales_rank = 2
            },
            new SalesRankedData
            {
                 City = "mumbai",
                 Id = 1,
                 Product = "VA1",
                 Week_Total = 1223243,
                 Sales_rank = 3
            }
        };

        public static ModelData modelData = new ModelData
        {
            Product = "V1",
            Week_Total = 234234342
        };

        public static List<ModelData> modelDataList = new List<ModelData>()
        {
            new ModelData
            {
                Product = "V1",
                Week_Total = 23423432
            },
            new ModelData
            {
                Product = "V2",
                Week_Total = 23234342
            },
            new ModelData
            {
                Product = "V3",
                Week_Total = 23423442
            }
        };
    }
}
