using System;
using System.Collections.Generic;
using System.Linq;
using Api.DataFiles;
using Api.Enums;
using Api.Interfaces;
using Newtonsoft.Json;

namespace Api.Utils
{
    public class FundsHelper : IFundsHelper
    {
        private readonly ILogHelper logHelper;
        private readonly IMapper mapper;

        // Constructor
        public FundsHelper(ILogHelper _logHelper, IMapper _mapper)
        {
            logHelper = _logHelper;
            mapper = _mapper;
        }

        // Public methods
        public List<FundDetails> GetFunds()
        {
            // Log the request
            logHelper.LogMessage(
                LogMessageType.Info,
                $"Request received to '/funds' API at: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}"
            );

            // Get funds, convert & map
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;
            var fundsDTO = JsonConvert.DeserializeObject<List<FundDetailsDTO>>(file);
            var funds = mapper.MapFunds(fundsDTO);

            // Return all funds
            return funds;
        }

        public FundDetails GetFundByMarketCode(string marketCode)
        {
            // Log the request
            logHelper.LogMessage(LogMessageType.Info,
                $"Request received to '/fund' API at: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}"
            );

            // Get funds, convert & map
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;
            var fundsDTO = JsonConvert.DeserializeObject<List<FundDetailsDTO>>(file);
            var funds = mapper.MapFunds(fundsDTO);

            // Return a specific fund
            return funds.Single(x => x.Code == marketCode);
        }

        public List<FundDetails> GetFundsByFundManager(string manager)
        {
            // Log the request
            logHelper.LogMessage(
                LogMessageType.Info,
                $"Request received to '/managerfunds' API at: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}"
            );

            // Get funds, convert & map
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;
            var fundsDTO = JsonConvert.DeserializeObject<List<FundDetailsDTO>>(file);
            var funds = mapper.MapFunds(fundsDTO);

            // NOTES ***************************************************
            //
            // Is this right? We are matching 'manager' against 'name'
            // property? Not the 'fundManager' property? I've kept as
            // per source code, but seems weird enough that I would 
            // query it. Given that the 'name' property includes spaces,
            // it would be prudent to note that the responsibility for
            // ensuring URLs are encoded correctly lies with the consumer
            // e.g, to get funds with name "Comtext 7755", the URL sent to
            // the api would be '/managerfunds/Comtext%207755'
            // *********************************************************

            // Return all funds for manager
            return funds.Where(x => x.Name == manager).ToList();
        }
    }
}