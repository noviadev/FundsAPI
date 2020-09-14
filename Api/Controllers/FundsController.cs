using FundsApi.Core.Controllers;
using FundsApi.Core.Entities;
using FundsApi.Core.Services;

namespace Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.IO;

    public class FundsController : Controller, IFundsController
    {
        private readonly IFundByMarketCodeGetter _fundByMarketCodeGetter;

        public FundsController(
            IFundByMarketCodeGetter fundByMarketCodeGetter)
        {
            _fundByMarketCodeGetter = fundByMarketCodeGetter ?? throw new ArgumentNullException(nameof(fundByMarketCodeGetter));
        }

        [Route("get-funds")]
        public IActionResult GetFunds(string id)
        {
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            if (id != null)
            {
                return this.Ok(funds.Single(x => x.MarketCode == id)); //API is Id but searches by MarketCode
            }
            
            return this.Ok(funds);
        }

        [Route("get-managerfunds")]
        public IActionResult GetManagerFunds(string manager)
        {
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            return this.Ok(funds.Where(x => x.Name == manager)); //API is fund manager but searches by name
        }

        [HttpGet("fund/code/{code}")]
        public IActionResult GetFundByCode(string code)
        {
            var fund = _fundByMarketCodeGetter.GetFund(code);
            if (fund is null)
            {
                return this.NotFound();
            }

            return this.Ok(fund);
        }
    }
}