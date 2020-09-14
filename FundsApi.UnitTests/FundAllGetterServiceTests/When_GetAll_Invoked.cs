using System;
using System.Collections.Generic;
using System.Text;
using FundsApi.Core.Entities.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace FundsApi.UnitTests.FundAllGetterServiceTests
{
    public class When_GetAll_Invoked : Given_A_FundAllGetterService
    {
        private IList<IFundDetailsEntity> _result;
        private IList<IFundDetailsEntity> _expected;

        public override void Because()
        {
            _expected = new List<IFundDetailsEntity>
            {
                {Substitute.For<IFundDetailsEntity>()}
            };
            MockFundDetailsEntityLoader.Load().Returns(_expected);
            _result = SUT.GetAll();
        }

        [Test]
        public void Then_Result_Should_Be_Expected()
        {
            _result.ShouldBe(_expected);
        }
    }
}
