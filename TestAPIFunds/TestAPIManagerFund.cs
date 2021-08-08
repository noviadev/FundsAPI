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
    public class TestAPIManagerFund {
        //private ConvertToPublic _converter;
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
        public void GetFundByManager() {
            // Arrange            
            string manager = "Furnigeer";

            // Act
            List<FundDetailsPublic> funds = (_fundController.GetManagerFunds(manager) as OkObjectResult).Value as List<FundDetailsPublic>;

            // Assert
            Assert.IsNotNull(funds);
            Assert.IsTrue(funds.Count > 0);
        }
        [Test]
        public void GetFundByManagerInvalid() {
            // Arrange            
            string manager = "invalidManager";

            // Act
            var funds = (_fundController.GetManagerFunds(manager) as OkObjectResult);

            // Assert
            Assert.IsNull(funds);
        }
    }
}