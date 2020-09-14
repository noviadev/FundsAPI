using FundsApi.Core.Entities;
using FundsApi.Core.Entities.Interfaces;

namespace FundsApi.Core.Services
{
    public interface IFundByMarketCodeGetter
    {
        IFundDetailsEntity GetFund(
            string code);
    }
}