using System;
using System.Collections.Generic;
using System.Text;
using FundsApi.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace FundsApi.UnitTests.FundsControllerTests
{
    class When_GetFundByMarketCode_NotFound_Invoked : Given_A_FundsController
    {
        private IActionResult _result;

        public override void Because()
        {
            MockFundByMarketCodeGetter.GetFund(null).Returns((IFundDetailsEntity) null);
            _result = SUT.GetFundByCode(null);
        }

        [Test]
        public void Then_Result_Should_Be_Not_Found()
        {
            _result.GetType().ShouldBe(typeof(NotFoundResult));
        }
    }
}
