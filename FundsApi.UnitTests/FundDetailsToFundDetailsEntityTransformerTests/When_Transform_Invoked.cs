using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsApi.Core.Entities;
using FundsApi.Core.Entities.Interfaces;
using NUnit.Framework;
using Shouldly;

namespace FundsApi.UnitTests.FundDetailsToFundDetailsEntityTransformerTests
{
    public class When_Transform_Invoked : Given_A_FundDetailsToFundDetailsEntityTransformer
    {
        private IList<FundDetails> _fundEntities = new List<FundDetails>
        {
            new FundDetails
            {
                Active = ExpectedActive,
                CurrentUnitPrice = ExpectedPrice,
                FundManager = ExpectedFundManager,
                MarketCode = ExpectedMarketCode,
                Name = ExpectedName
            }
        };

        private static bool ExpectedActive = true;
        private static string ExpectedFundManager = "FundFoo";
        private static string ExpectedMarketCode = "CodeBar";
        private static string ExpectedName = "NameTest";
        private static decimal ExpectedPrice = 2.12345m;
        private IList<IFundDetailsEntity> _result;
        private IFundDetailsEntity _firstResult;

        public override void Because()
        {
            _fundEntities = new List<FundDetails>
            {
                {new FundDetails
                {
                    Name = ExpectedName,
                    Active = ExpectedActive,
                    FundManager = ExpectedFundManager,
                    MarketCode = ExpectedMarketCode,
                    CurrentUnitPrice = ExpectedPrice
                }}
            };
            _result = SUT.Transform(_fundEntities);
            _firstResult = _result.First();
        }

        [Test]
        public void Then_Result_First_Active_Should_Be_Expected()
        {
            _firstResult.Active.ShouldBe(ExpectedActive);
        }

        [Test]
        public void Then_Result_First_FundManager_Should_Be_Expected()
        {
            _firstResult.FundManager.ShouldBe(ExpectedFundManager);
        }

        [Test]
        public void Then_Result_First_Code_Should_Be_Expected()
        {
            _firstResult.Code.ShouldBe(ExpectedMarketCode);
        }

        [Test]
        public void Then_Result_First_Name_Should_Be_Expected()
        {
            _firstResult.Name.ShouldBe(ExpectedName);
        }

        [Test]
        public void Then_Result_First_CurrentUnitPrice_Should_Be_Expected_To_Two_Decimal_Places()
        {
            _firstResult.CurrentUnitPrice.ShouldBe(Decimal.Round(ExpectedPrice, 2));
        }
    }
}
