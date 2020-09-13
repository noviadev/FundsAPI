using System;
using System.Collections.Generic;
using System.Text;
using Api.Controllers;
using FundsApi.Core.Controllers;
using FundsApi.Core.Services;
using NSubstitute;

namespace FundsApi.UnitTests.FundsControllerTests
{
    public class Given_A_FundsController : BaseUnitTests<IFundsController>
    {

        protected IFundByMarketCodeGetter MockFundByMarketCodeGetter;

        public override void SetContext()
        {
            Substitute.For<IFundByMarketCodeGetter>();

            SUT = new FundsController();
        }
    }
}
