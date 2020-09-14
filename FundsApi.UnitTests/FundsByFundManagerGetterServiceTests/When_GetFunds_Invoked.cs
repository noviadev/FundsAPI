using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsApi.Core.Entities.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace FundsApi.UnitTests.FundsByFundManagerGetterServiceTests
{
    public class When_GetFunds_Invoked : Given_A_FundsByFundManagerGetterService
    {
        private IList<IFundDetailsEntity> _result;
        private IList<IFundDetailsEntity> _expected;
        private IFundDetailsEntity _fund1;
        private IFundDetailsEntity _fund2;

        public override void Because()
        {
            _fund1 = Substitute.For<IFundDetailsEntity>();
            _fund2 = Substitute.For<IFundDetailsEntity>();
            _expected = new List<IFundDetailsEntity>
            {
                {Substitute.For<IFundDetailsEntity>()},
                {_fund1},
                {_fund2},
            };

            var fundManager = "test";

            _fund1.FundManager.Returns(fundManager);
            _fund2.FundManager.Returns(fundManager);

            MockFundDetailsEntityLoader.Load().Returns(_expected);
            _result = SUT.GetFunds(fundManager);
        }

        [Test]
        public void Then_First_Fund_Should_Be_Expected()
        {
            _result[0].ShouldBe(_fund1);
        }

        [Test]
        public void Then_Second_Fund_Should_Be_Expected()
        {
            _result[1].ShouldBe(_fund2);
        }
    }
}
