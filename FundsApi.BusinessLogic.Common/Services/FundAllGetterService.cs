using System.Collections.Generic;
using FundsApi.Core.Entities.Interfaces;
using FundsApi.Core.Services;

namespace FundsApi.BusinessLogic.Common.Services
{
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