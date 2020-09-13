using FundsApi.Core.Entities;

namespace FundsApi.Core.Services
{
    public interface IFundByMarketCodeGetter
    {
        IFundDetailsEntity GetFund(
            string code);
    }
}