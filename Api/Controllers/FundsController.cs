using Audit.Mvc;
using FundsApi.Core.Controllers;
using FundsApi.Core.Entities;
using FundsApi.Core.Entities.Interfaces;
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
        private readonly IFundAllGetter _fundAllGetter;
        private readonly IFundsByFundManagerGetter _fundsByFundManagerGetter;

        public FundsController(
            IFundByMarketCodeGetter fundByMarketCodeGetter, 
            IFundAllGetter fundAllGetter,
            IFundsByFundManagerGetter fundsByFundManagerGetter)
        {
            _fundByMarketCodeGetter = fundByMarketCodeGetter ?? throw new ArgumentNullException(nameof(fundByMarketCodeGetter));
            _fundAllGetter = fundAllGetter ?? throw new ArgumentNullException(nameof(fundAllGetter));
            _fundsByFundManagerGetter = fundsByFundManagerGetter ?? throw new ArgumentNullException(nameof(fundsByFundManagerGetter));
        }

        [Route("get-funds")]
        [Audit]
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
        [Audit]
        public IActionResult GetManagerFunds(string manager)
        {
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            return this.Ok(funds.Where(x => x.Name == manager)); //API is fund manager but searches by name
        }

        [HttpGet("fund/code/{code}")]
        [Audit]
        public IActionResult GetFundByCode(string code)
        {
            var fund = _fundByMarketCodeGetter.GetFund(code);
            if (fund is null)
            {
                return this.NotFound();
            }

            return this.Ok(fund);
        }

        [HttpGet("funds")]
        [Audit]
        public IActionResult GetAllFunds()
        {
            var funds = _fundAllGetter.GetAll();

            return this.Ok(funds);
        }

        [HttpGet("funds/fundmanager/{fundManager}")]
        [Audit]
        public IActionResult GetFundByFundManager(string fundManager)
        {
            var funds = _fundsByFundManagerGetter.GetFunds(fundManager);
            return this.Ok(funds);
        }
    }
}