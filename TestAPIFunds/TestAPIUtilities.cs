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
    class TestAPIUtilities {
        [SetUp]
        public void Setup() {
        }
        [Test]
        public void WriteToEventLog() {
            // Arrange            
            EventLogLogger _logMessage = new EventLogLogger(); ;
            string testMessage = "Test message to event log";
            // Act
            _logMessage.WriteToLog(testMessage);

            // Assert
            Assert.Pass();
        }
        [Test]
        public void ReadJSONFile() {
            // Arrange            
            JSON _dataAccess = new JSON(); ;

            // Act
            List<FundDetails> funds = _dataAccess.GetData();

            // Assert
            Assert.IsTrue(funds.Count > 0);
        }
    }
}
