using System;
using System.Collections.Generic;
using System.Text;
using FundsApi.Core.Entities;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace FundsApi.UnitTests.FundByMarketCodeGetterServiceTests
{
    public class When_GetFund_Invoked : Given_A_FundByMarketCodeGetterService
    {
        private IFundDetailsEntity _expectedFund;
        private IFundDetailsEntity _result;

        public override void Because()
        {
            var code = "Test";
            _expectedFund = Substitute.For<IFundDetailsEntity>();
            _expectedFund.Code.Returns(code);
            IList<IFundDetailsEntity> funds = new List<IFundDetailsEntity>
            {
                {Substitute.For<IFundDetailsEntity>()},
                {_expectedFund},
            };
            MockFundDetailsEntityLoader.Load().Returns(funds);
            _result = SUT.GetFund(code);
        }

        [Test]
        public void Then_Result_Should_Be_Expected()
        {
            _result.ShouldBe(_expectedFund);
        }
    }
}
