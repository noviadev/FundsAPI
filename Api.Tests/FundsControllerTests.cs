using Moq;
using NUnit.Framework;
using Api.Interfaces;
using Api.DataFiles;
using Api.Controllers;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;

namespace Api.Tests
{
    [TestFixture]
    public class FundsControllerTests
    {
        FundsController controller;
        Mock<IFundsHelper> mockFundsHelper;

        [SetUp]
        public void Setup()
        {
            mockFundsHelper = new Mock<IFundsHelper>();
            controller = new FundsController(mockFundsHelper.Object);
        }

        [Test]
        public void GetFunds_MakesCallTo_FundsHelperGetFunds()
        {
            // Arrange            
            List<FundDetails> fakeList = new List<FundDetails>()
            {
                new FundDetails(){ Active = true, CurrentUnitPrice = 12.34m, Code = "FAKECODE", FundManager = "FakeManager", Name = "Fake Name"},
                new FundDetails(){ Active = false, CurrentUnitPrice = 43.21m, Code = "FAKECODE", FundManager = "FakeManager", Name = "Fake Name"}
            };

            mockFundsHelper.Setup(mfh => mfh.GetFunds()).Returns(fakeList);

            // Act
            var funds = controller.GetFunds();

            // Assert that fundsHelper was called 
            mockFundsHelper.Verify((mfh => mfh.GetFunds()), Times.Once);
        }

        [Test]
        public void GetFund_MakesCallTo_FundsHelperGetFund()
        {
            // Arrange            
            FundDetails fakeFund = new FundDetails()
            {
                Active = true,
                CurrentUnitPrice = 12.34m,
                Code = "FAKECODE",
                FundManager = "FakeManager",
                Name = "Fake Name"
            };

            mockFundsHelper.Setup(mfh => mfh.GetFundByMarketCode("FAKECODE")).Returns(fakeFund);

            // Act
            var fund = controller.GetFundByMarketCode("FAKECODE");

            // Assert that fundsHelper was called 
            mockFundsHelper.Verify((mfh => mfh.GetFundByMarketCode("FAKECODE")), Times.Once);
        }

        [Test]
        public void GetManagerFunds_MakesCallTo_FundsHelperGetFundsByFundManager()
        {
            // Arrange            
            List<FundDetails> fakeList = new List<FundDetails>()
            {
                new FundDetails(){ Active = true, CurrentUnitPrice = 12.34m, Code = "FAKECODE", FundManager = "FakeManager", Name = "Fake Name"},
                new FundDetails(){ Active = false, CurrentUnitPrice = 43.21m, Code = "FAKECODE", FundManager = "FakeManager", Name = "Fake Name"}
            };

            mockFundsHelper.Setup(mfh => mfh.GetFundsByFundManager("FakeManager")).Returns(fakeList);

            // Act
            var fund = controller.GetFundByMarketCode("FAKECODE");

            // Assert that fundsHelper was called 
            mockFundsHelper.Verify((mfh => mfh.GetFundByMarketCode("FAKECODE")), Times.Once);
        }
    }
}