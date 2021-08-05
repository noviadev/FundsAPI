using Api.Controllers;
using Api.DAO;
using Api.DataFiles;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;

namespace Api.Test
{
    public class FundsTest
    {
        private Mock<ILogger<FundsController>> _logger;
        private FundsDAO _fundsDAO;
        private FundsController _fundsController;
        
        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<FundsController>>();
            _fundsDAO = new FundsDAO();
            _fundsController = new FundsController(_logger.Object, _fundsDAO);
        }

        [Test]
        public void Get_Funds_Returns_Ok()
        {
            var result = _fundsController.GetFunds(null);
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }


        [Test]
        public void Get_Funds_With_No_Id_Value()
        {
            var result = _fundsController.GetFunds(null);
            var okResult = result as OkObjectResult;
            
            Assert.IsNotNull(okResult);

            var funds = okResult.Value as ICollection<FundDetailsOutput>;

            Assert.IsNotNull(funds);

            Assert.IsTrue(funds.Count > 0);
        }

        [Test]
        public void Get_Funds_With_Valid_Existing_Id()
        {
            var marketCode = "OCCAECAT";

            var result = _fundsController.GetFunds(marketCode);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);

            var funds = okResult.Value as FundDetailsOutput;

            Assert.IsNotNull(funds);
        }

        [Test]
        public void Get_Funds_With_Valid_Id_No_Results_Not_Found()
        {
            var marketCode = "AABBCCDD";

            var result = _fundsController.GetFunds(marketCode);
            var nfResult = result as NotFoundResult;

            Assert.AreEqual(404, nfResult.StatusCode);
        }

        [Test]
        public void Get_Manager_Funds_With_Valid_Manager_Returns_Ok()
        {
            var manager = "Isotrack";
            var result = _fundsController.GetManagerFunds(manager);
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Get_Manager_Funds_With_No_Value_Returns_Not_Found()
        {
            var result = _fundsController.GetManagerFunds(null);
            var nfResult = result as NotFoundResult;

            Assert.IsNotNull(nfResult);
            Assert.AreEqual(404, nfResult.StatusCode);
        }

        [Test]
        public void Get_Manager_Funds_With_Valid_Existing_Manager()
        {
            var manager = "Isoplex";
            var result = _fundsController.GetManagerFunds(manager);
            var okResult = result as OkObjectResult;

            var funds = okResult.Value as List<FundDetailsOutput>;

            Assert.IsNotNull(funds);
            Assert.IsTrue(funds.Count>0);
            
        }

        [Test]
        public void Get_Manager_Funds_With_Valid_Input_No_Results_Returns_Not_Found()
        {
            var manager = "Philplex";
            var result = _fundsController.GetManagerFunds(manager);
            var nfResult = result as NotFoundResult;

            Assert.IsNotNull(nfResult);
            Assert.AreEqual(404, nfResult.StatusCode);
        }

    }
}