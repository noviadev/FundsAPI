namespace Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Api.DataFiles;
    using Api.Models;
    using Microsoft.Extensions.Logging;

    [Route("/funds")]
    public class FundsController : Controller
    {
        private readonly ILogger _logger;
        public FundsController(ILogger<FundsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get-funds")]
        public IActionResult GetFunds(string id)
        {
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            if (id != null)
            {
                var fundsToProcess = funds.Where(f => f.MarketCode == id);

                _logger.LogInformation($"Fund with MarketCode {id} accessed");
                return this.Ok(GetPublicDto(fundsToProcess));
            }

            _logger.LogInformation($"Funds with MarketCode {id} accessed");
            return this.Ok(GetPublicDto(funds));
        }

        [HttpGet("get-managerfunds/{manager}")]
        public IActionResult GetManagerFunds(string manager)
        {
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert
                .DeserializeObject<List<FundDetails>>(file)
                .Where(x => x.Name == manager);

            _logger.LogInformation($"Funds for Manager {manager} accessed");
            return this.Ok(GetPublicDto(funds));
        }

        public static List<FundDetailsDto> GetPublicDto(IEnumerable<FundDetails> funds)
        {
            var publicFunds = new List<FundDetailsDto>();

            foreach (var fund in funds)
            {
                publicFunds.Add(new FundDetailsDto
                {
                    Active = fund.Active,
                    CurrentUnitPrice = decimal.Round(fund.CurrentUnitPrice, 2),
                    FundManager = fund.FundManager,
                    Name = fund.Name,
                    Code = fund.MarketCode
                });
            }

            return publicFunds;
        }
    }
}