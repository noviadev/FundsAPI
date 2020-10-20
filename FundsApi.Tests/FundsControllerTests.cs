using Api.Controllers;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FundsApi.Tests
{
    public class FundsControllerTests
    {
        [Fact]
        public void GetFunds_ShouldReturnNoContent_WhenGivenInvalidMarketCode()
        {
            // Arange
            var mock = new Mock<ILogger>();
            var invalidMarketCode = "testcode";
            var controller = new FundsController(mock.Object);

            // Act
            var actionResult = controller.GetFunds(invalidMarketCode);
            var noContentResult = actionResult as NoContentResult;

            // Assert
            Assert.NotNull(noContentResult);
            Assert.Equal(204, noContentResult.StatusCode);
        }

        [Fact]
        public void GetFunds_ShouldReturnFunds_WhenGivenValidMarketCode()
        {
            // Arange
            var mock = new Mock<ILogger>();
            var validMarketCode = "EA";
            var controller = new FundsController(mock.Object);

            // Act
            var actionResult = controller.GetFunds(validMarketCode);
            var okObjectResult = actionResult as OkObjectResult;

            // Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(200, okObjectResult.StatusCode);
            
            var funds = okObjectResult.Value as IEnumerable<Api.DataFiles.FundDetails>;
            Assert.NotNull(funds);

            var fund = funds.FirstOrDefault();
            var actual = fund.Code;
            Assert.Equal(validMarketCode, actual);
        }

        [Fact]
        public void GetFunds_ShouldReturnAllFunds_WhenGivenNoMarketCode()
        {
            // Arange
            var mock = new Mock<ILogger>();
            var controller = new FundsController(mock.Object);

            // Act
            var actionResult = controller.GetFunds();
            var okObjectResult = actionResult as OkObjectResult;

            // Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(200, okObjectResult.StatusCode);

            var funds = okObjectResult.Value as IEnumerable<Api.DataFiles.FundDetails>;
            Assert.NotNull(funds);
            Assert.Equal(15, funds.Count());
        }

        [Fact]
        public void GetManagerFunds_ShouldReturnFunds_WhenGivenValidManager()
        {
            // Arange
            var mock = new Mock<ILogger>();
            var controller = new FundsController(mock.Object);
            var manager = "Furnigeer";

            // Act
            var actionResult = controller.GetManagerFunds(manager);
            var okObjectResult = actionResult as OkObjectResult;

            // Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(200, okObjectResult.StatusCode);

            var funds = okObjectResult.Value as IEnumerable<Api.DataFiles.FundDetails>;
            Assert.NotNull(funds);

            var fund = funds.FirstOrDefault();
            var actual = fund.FundManager;
            Assert.Equal(manager, actual);
        }
    }
}
