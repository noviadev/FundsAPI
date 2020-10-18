namespace Api.Controllers
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Api.DataFiles;
    using Api.Interfaces;

    public class FundsController : Controller
    {
        private readonly IFundsHelper fundsHelper;

        public FundsController(IFundsHelper _fundsHelper)
        {
            fundsHelper = _fundsHelper;
        }

        [HttpGet("funds")]
        public IActionResult GetFunds()
        {
            List<FundDetails> funds = fundsHelper.GetFunds();
            return Ok(funds);
        }

        [HttpGet("fund/{marketCode}")]
        public IActionResult GetFundByMarketCode(string marketCode)
        {
            FundDetails fund = fundsHelper.GetFundByMarketCode(marketCode);
            return Ok(fund);
        }

        [HttpGet("managerfunds/{manager}")]
        public IActionResult GetManagerFunds(string manager)
        {
            var funds = fundsHelper.GetFundsByFundManager(manager);
            return Ok(funds.Where(x => x.Name == manager));
        }
    }
}