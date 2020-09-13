using System;
using System.Collections.Generic;
using System.Text;
using FundsApi.BusinessLogic.Common.Services;
using FundsApi.Core.Services;
using NSubstitute;

namespace FundsApi.UnitTests.FundByMarketCodeGetterServiceTests
{
    public class Given_A_FundByMarketCodeGetterService : BaseUnitTests<IFundByMarketCodeGetter>
    {
        protected IFundDetailsEntityLoader MockFundDetailsEntityLoader;

        public override void SetContext()
        {
            MockFundDetailsEntityLoader = Substitute.For<IFundDetailsEntityLoader>();

            SUT = new FundByMarketCodeGetterService(
                MockFundDetailsEntityLoader );
        }
    }
}
