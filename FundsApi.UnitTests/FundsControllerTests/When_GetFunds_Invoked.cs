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
    public class When_GetFunds_Invoked : Given_A_FundsController
    {
        private OkObjectResult _result;

        public override void Because()
        {
            _result = (OkObjectResult)SUT.GetFunds(null);
        }

        [Test]
        public void Then_Result_Should_Contain_FundDetails()
        {
            var value = _result.Value as List<FundDetails>;
            value.First().ShouldNotBeNull();
        }

    }
}
