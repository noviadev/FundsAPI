using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsApi.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shouldly;

namespace FundsApi.UnitTests.FundsControllerTests
{
    public class When_GetFunds_Id_Invoked : Given_A_FundsController
    {
        private OkObjectResult _result;
        private string _expectedMarketCode = "SUNT";

        public override void Because()
        {
            _result = (OkObjectResult) SUT.GetFunds(_expectedMarketCode);
        }

        //Bad test, data dependent
        [Test]
        public void Then_Result_Should_Be_Expected()
        {
            var value = _result.Value as FundDetails;
            value.MarketCode.ShouldBe(_expectedMarketCode);
        }
    }
}
