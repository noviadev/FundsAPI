using System;
using System.Collections.Generic;
using System.Text;
using FundsApi.Core.Controllers;
using FundsApi.Core.Entities;
using FundsApi.Core.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace FundsApi.UnitTests.FundsControllerTests
{
    public class When_GetFundByMarketCode_Invoked : Given_A_FundsController
    {
        private OkObjectResult _result;
        private IFundDetailsEntity _expected;

        public override void Because()
        {
            var code = "FooBar";
            _expected = Substitute.For<IFundDetailsEntity>();
            MockFundByMarketCodeGetter.GetFund(code).Returns(_expected);
            _result = (OkObjectResult) SUT.GetFundByCode(
                code);
        }

        [Test]
        public void Then_Result_Should_Be_Expected()
        {
            _result.Value.ShouldBe(_expected);
        }
    }
}
