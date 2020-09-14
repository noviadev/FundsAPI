using System;
using System.Collections.Generic;
using System.Linq;
using FundsApi.Core.Entities.Interfaces;
using FundsApi.Core.Services;

namespace FundsApi.BusinessLogic.Common.Services
{
    public class FundsByFundManagerGetterService : IFundsByFundManagerGetter
    {
        private readonly IFundDetailsEntityLoader _fundDetailsEntityLoader;

        public FundsByFundManagerGetterService(IFundDetailsEntityLoader fundDetailsEntityLoader)
        {
            _fundDetailsEntityLoader = fundDetailsEntityLoader ?? throw new ArgumentNullException(nameof(fundDetailsEntityLoader));
        }

        public IList<IFundDetailsEntity> GetFunds(string fundManager)
        {
            var funds = _fundDetailsEntityLoader.Load();
            return funds.Where(x => x.FundManager == fundManager).ToList();
        }
    }
}