using System;
using System.Collections.Generic;
using System.Text;
using FundsApi.Core.Entities;
using FundsApi.Core.Entities.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace FundsApi.UnitTests.FundDetailsEntityLoader
{
    public class When_Load_Invoked : Given_A_FundDetailsEntityLoader
    {
        private IList<IFundDetailsEntity> _result;
        private IList<IFundDetailsEntity> _expected;

        public override void Because()
        {
            _expected = new List<IFundDetailsEntity>();
            var funds = new List<FundDetails>();
            MockFundDetailsRepository.All().Returns(funds);
            MockFundDetailsToFundDetailsEntityTransformer.Transform(funds).Returns(_expected);
            _result = SUT.Load();
        }

        [Test]
        public void Then_Result_Should_Be_Expected()
        {
            _result.ShouldBe(_expected);
        }
    }
}
