using System;
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
        protected IFundAllGetter MockFundAllGetter;

        public override void SetContext()
        {
            MockFundByMarketCodeGetter = Substitute.For<IFundByMarketCodeGetter>();
            MockFundAllGetter = Substitute.For<IFundAllGetter>();

            SUT = new FundsController(
                MockFundByMarketCodeGetter,
                MockFundAllGetter );
        }
    }
}
