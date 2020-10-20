namespace Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.IO;
    using Api.DataFiles;
    using Api.Interfaces;

    [Route("api/[controller]")]
    public class FundsController : ControllerBase
    {
        private readonly ILogger _logger;

        public FundsController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{marketCode}")]
        public IActionResult GetFunds(string marketCode)
        {
            _logger.LogInfo("Retrieving funds for market code:" + marketCode);

            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            var result = funds.Where(x => x.Code == marketCode);

            if (marketCode != null)
            {
                // Two funds with marketcode 'EA', error thrown with defualt code.
                if (result.Count() > 1){
                    _logger.LogSuccess(result.Count()+" funds found for market code: " + marketCode);
                    return Ok(result);
                }

                if(result.Count() == 1)
                {
                    _logger.LogSuccess("Single fund found for market code: " + marketCode);
                    return Ok(result);
                }

                _logger.LogError("No funds found for market code:" + marketCode);
                return NoContent();
            }

            return GetFunds();
        }

        [HttpGet]
        public IActionResult GetFunds()
        {
            _logger.LogInfo("Retrieving all funds.");

            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            return Ok(funds);
        }


        [HttpGet]
        [Route("Manager/{manager}")]
        public IActionResult GetManagerFunds(string manager)
        {
            _logger.LogInfo("Retrieving funds found for fund manager: " + manager);

            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            return Ok(funds.Where(x => x.FundManager == manager));
        }
    }
}