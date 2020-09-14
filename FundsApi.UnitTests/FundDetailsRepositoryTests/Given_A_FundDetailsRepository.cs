using System;
using System.Text;
using FundsApi.BusinessLogic.Common.Repository;
using FundsApi.Core.Repositories;

namespace FundsApi.UnitTests.FundDetailsRepositoryTests
{
    public class Given_A_FundDetailsRepository : BaseUnitTests<IFundDetailsRepository>
    {
        public override void SetContext()
        {
            SUT = new FundDetailsRepository();
        }
    }
}
