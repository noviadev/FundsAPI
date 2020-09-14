using System.Collections.Generic;
using FundsApi.Core.Entities;
using FundsApi.Core.Repositories;
using Newtonsoft.Json;

namespace FundsApi.BusinessLogic.Common.Repository
{
    public class FundDetailsRepository : IFundDetailsRepository
    {

        public IList<FundDetails> All()
        {
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            return funds;
        }
    }
}