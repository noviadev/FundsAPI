using Api.DataFiles;
using System.Collections.Generic;

namespace Api.Interfaces
{
    public interface IFundsDAO
    {
        List<FundDetailsOutput> GetFundsData();
        FundDetailsOutput TranslateSingleToOutput(FundDetails fund);

        List<FundDetailsOutput> TranslateFundsToOutput(List<FundDetails> lstFunds);
    }
}