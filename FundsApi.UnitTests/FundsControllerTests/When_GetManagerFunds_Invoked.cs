using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.DataFiles;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shouldly;

namespace FundsApi.UnitTests.FundsControllerTests
{
    public class When_GetManagerFunds_Invoked : Given_A_FundsController
    {
        private OkObjectResult _result;
        const string ExpectedFundManager = "Exostream 2095";

        public override void Because()
        {
            _result = (OkObjectResult) SUT.GetManagerFunds(ExpectedFundManager);
        }

        //Bad test, data dependent
        [Test]
        public void Then_Result_Should_Be_Expected_Name()
        {
            var value = _result.Value as IEnumerable<FundDetails>;
            value.ToList().All(x => x.Name == ExpectedFundManager).ShouldBeTrue();
        }
    }
}
