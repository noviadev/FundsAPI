using System;
using System.Collections.Generic;
using System.Text;
using FundsApi.Core.Entities.Interfaces;
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

    public class FundAllGetterService : IFundAllGetter
    {
        private readonly IFundDetailsEntityLoader _fundDetailsEntityLoader;

        public FundAllGetterService(IFundDetailsEntityLoader fundDetailsEntityLoader)
        {
            _fundDetailsEntityLoader = fundDetailsEntityLoader;
        }

        public IList<IFundDetailsEntity> GetAll()
        {
            return _fundDetailsEntityLoader.Load();
        }
    }
}
