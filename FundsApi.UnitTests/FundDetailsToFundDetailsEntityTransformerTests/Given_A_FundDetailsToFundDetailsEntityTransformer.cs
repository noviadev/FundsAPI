using System.Text;
using FundsApi.BusinessLogic.Common.Services.Transformers;
using FundsApi.Core.Services.Transformers;

namespace FundsApi.UnitTests.FundDetailsToFundDetailsEntityTransformerTests
{
    public class Given_A_FundDetailsToFundDetailsEntityTransformer : BaseUnitTests<IFundDetailsToFundDetailsEntityTransformer>
    {
        public override void SetContext()
        {
            SUT = new FundDetailsToFundDetailsEntityTransformer();
        }
    }
}
