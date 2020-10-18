using System.Collections.Generic;
using Api.DataFiles;

namespace Api.Interfaces
{
    public interface IFundsHelper
    {
        // Get all funds
        List<FundDetails> GetFunds();

        // Get fund by market code
        FundDetails GetFundByMarketCode(string marketCode);

        // Get funds by fund manager
        List<FundDetails> GetFundsByFundManager(string fundManager);
    }
}