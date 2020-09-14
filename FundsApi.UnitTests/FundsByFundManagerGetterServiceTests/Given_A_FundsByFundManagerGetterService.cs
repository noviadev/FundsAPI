using FundsApi.BusinessLogic.Common.Services;
using FundsApi.Core.Services;
using NSubstitute;

namespace FundsApi.UnitTests.FundsByFundManagerGetterServiceTests
{
    public class Given_A_FundsByFundManagerGetterService : BaseUnitTests<IFundsByFundManagerGetter>
    {
        protected IFundDetailsEntityLoader MockFundDetailsEntityLoader;

        public override void SetContext()
        {
            MockFundDetailsEntityLoader = Substitute.For<IFundDetailsEntityLoader>();
            SUT = new FundsByFundManagerGetterService(
                MockFundDetailsEntityLoader );
        }
    }
}
