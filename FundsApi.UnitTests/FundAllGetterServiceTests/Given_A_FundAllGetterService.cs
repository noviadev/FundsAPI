using System;
using System.Text;
using FundsApi.BusinessLogic.Common.Services;
using FundsApi.Core.Services;
using NSubstitute;

namespace FundsApi.UnitTests.FundAllGetterServiceTests
{
    public class Given_A_FundAllGetterService : BaseUnitTests<IFundAllGetter>
    {
        protected IFundDetailsEntityLoader MockFundDetailsEntityLoader;
        public override void SetContext()
        {
            MockFundDetailsEntityLoader = Substitute.For<IFundDetailsEntityLoader>();
            SUT = new FundAllGetterService(
                MockFundDetailsEntityLoader);
        }
    }
}
