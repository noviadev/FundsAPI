using System.Collections.Generic;
using Newtonsoft.Json;
using Api.Models;

namespace Api.DataAccess {
    public class JSON : IDataAccess {
       public List<FundDetails> GetData() {
            List<FundDetails> lstOutput = new List<FundDetails>();
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;
            List<FundDetails> funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);
            return funds;
        }
    }
}
