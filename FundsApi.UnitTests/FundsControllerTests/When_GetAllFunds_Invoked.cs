using System;
using System.Collections.Generic;
using System.Text;
using FundsApi.Core.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace FundsApi.UnitTests.FundsControllerTests
{
    public class When_GetAllFunds_Invoked : Given_A_FundsController
    {
        private OkObjectResult _result;
        private IList<IFundDetailsEntity> _expected;

        public override void Because()
        {
            _expected = new List<IFundDetailsEntity>
            {
                {Substitute.For<IFundDetailsEntity>()}
            };

            MockFundAllGetter.GetAll().Returns(_expected);
            _result = (OkObjectResult) SUT.GetAllFunds();
        }

        [Test]
        public void Then_Result_Should_Be_Expected()
        {
            _result.Value.ShouldBe(_expected);
        }
    }
}
