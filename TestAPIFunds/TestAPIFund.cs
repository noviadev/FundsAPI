using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Api.Models;
using Api.LogMessage;
using Api.DataAccess;
using Api.Converter;
using Api.Controllers;
using Api.Utilities;

namespace TestAPIFunds {
    public class TestAPIFund {
        EventLogLogger _LogMessage;
        JSON _DataAccess;
        RoundToTwo _MathsUtilities;

        private FundsController _fundController;
        [SetUp]
        public void Setup() {
            _LogMessage = new EventLogLogger();
            _DataAccess = new JSON();
            _MathsUtilities = new RoundToTwo();
            _fundController = new FundsController(_LogMessage, _DataAccess, _MathsUtilities);
        }

        [Test]
        public void GetFundByMarketCode() {
            // Arrange            
            string marketCode = "OCCAECAT";

            // Act
            var funds = (_fundController.GetFunds(marketCode) as OkObjectResult).Value as FundDetailsPublic;

            // Assert
            Assert.IsNotNull(funds);
        }
        [Test]
        public void GetFundByMarketCodeInvalid() {
            // Arrange            
            string marketCode = "invalidID";

            // Act
            var funds = (_fundController.GetFunds(marketCode) as OkObjectResult);

            // Assert
            Assert.IsNull(funds);
        }
        [Test]
        public void GetAllFunds() {
            // Arrange            
            string marketCode = null;

            // Act
            var funds = (_fundController.GetFunds(marketCode) as OkObjectResult).Value as List<FundDetailsPublic>;

            // Assert
            Assert.IsNotNull(funds);
            Assert.IsTrue(funds.Count > 0);
        }
    }
}