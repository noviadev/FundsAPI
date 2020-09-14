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
    public class When_GetFundByFundManager_Invoked : Given_A_FundsController
    {
        private OkObjectResult _result;
        private List<IFundDetailsEntity> _expected;

        public override void Because()
        {
            var manager = "FundFooBar";
            _expected = new List<IFundDetailsEntity>
            {
                {Substitute.For<IFundDetailsEntity>()}
            };
            MockFundsByFundManagerGetter.GetFunds(manager).Returns(_expected);
            _result = (OkObjectResult) SUT.GetFundByFundManager(
                manager);
        }

        [Test]
        public void Then_Result_Should_Be_Expected()
        {
            _result.Value.ShouldBe(_expected);
        }
    }
}
