using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsApi.Core.Entities;
using FundsApi.Core.Entities.Interfaces;
using FundsApi.Core.Services;

namespace FundsApi.BusinessLogic.Common.Services
{
    public class FundByMarketCodeGetterService : IFundByMarketCodeGetter
    {
        private readonly IFundDetailsEntityLoader _fundDetailsEntityLoader;

        public FundByMarketCodeGetterService(IFundDetailsEntityLoader fundDetailsEntityLoader)
        {
            _fundDetailsEntityLoader = fundDetailsEntityLoader ?? throw new ArgumentNullException(nameof(fundDetailsEntityLoader));
        }

        public IFundDetailsEntity GetFund(string code)
        {
            var funds = _fundDetailsEntityLoader.Load();
            var fund = funds.FirstOrDefault(x => x.Code == code);
            return fund;
        }
    }
}
