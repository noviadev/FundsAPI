using System;
using System.Text;
using FundsApi.BusinessLogic.Common.Services;
using FundsApi.Core.Repositories;
using FundsApi.Core.Services;
using FundsApi.Core.Services.Transformers;
using NSubstitute;
using NSubstitute.Core;

namespace FundsApi.UnitTests.FundDetailsEntityLoader
{
    public class Given_A_FundDetailsEntityLoader : BaseUnitTests<IFundDetailsEntityLoader>
    {

        protected IFundDetailsRepository MockFundDetailsRepository;
        protected IFundDetailsToFundDetailsEntityTransformer MockFundDetailsToFundDetailsEntityTransformer;

        public override void SetContext()
        {
            MockFundDetailsRepository = Substitute.For<IFundDetailsRepository>();
            MockFundDetailsToFundDetailsEntityTransformer =
                Substitute.For<IFundDetailsToFundDetailsEntityTransformer>();
            SUT = new FundDetailsEntityLoaderService(
                MockFundDetailsRepository,
                MockFundDetailsToFundDetailsEntityTransformer );
        }
    }
}
