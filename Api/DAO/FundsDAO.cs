using Api.DataFiles;
using Api.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DAO
{
    public class FundsDAO : IFundsDAO
    {
        public List<FundDetailsOutput> GetFundsData()
        {
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            var fundsOutput = TranslateFundsToOutput(funds);

            return fundsOutput;
        }

        public FundDetailsOutput TranslateSingleToOutput(FundDetails fund)
        {
            FundDetailsOutput output = new FundDetailsOutput()
            {
                Id = fund.Id,
                Active = fund.Active,
                CurrentUnitPrice = fund.CurrentUnitPrice,
                FundManager = fund.FundManager,
                Name = fund.Name,
                MarketCode = fund.MarketCode
            };

            return output;
        }

        public List<FundDetailsOutput> TranslateFundsToOutput(List<FundDetails> lstFunds)
        {
            List<FundDetailsOutput> lstOutput = new List<FundDetailsOutput>();

            foreach(FundDetails fund in lstFunds)
            {
                lstOutput.Add(TranslateSingleToOutput(fund));
            }

            return lstOutput;

        }
    }
}
