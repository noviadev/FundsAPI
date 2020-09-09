namespace Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Api.DataFiles;
    using Microsoft.AspNetCore.Http;
    using System.Text.RegularExpressions;

    public class FundsController : Controller
    {

        [HttpGet("get-funds/{code?}")]
        public IActionResult GetFunds([FromRoute] string code = null)
        {
            if (code != null && !Regex.IsMatch(code, "^[a-zA-Z ]*$"))
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            if (code != null)
            {
                try
                {
                    return this.Ok(new Fund(funds.Single(x => x.MarketCode == code)));
                }
                catch (InvalidOperationException)
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }

            List<Fund> fundResults = new List<Fund>();
            foreach (FundDetails f in funds)
            {
                fundResults.Add(new Fund(f));
            }
            return this.Ok(fundResults);
        }

        [HttpGet("get-managerfunds/{manager}")]
        public IActionResult GetManagerFunds([FromRoute] string manager)
        {
            if (manager == null || !Regex.IsMatch(manager, "^[a-zA-Z ]*$")) return new StatusCodeResult(StatusCodes.Status400BadRequest);

            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            List<Fund> fundResults = new List<Fund>();
            foreach (FundDetails f in funds)
            {
                fundResults.Add(new Fund(f));
            }

            return this.Ok(fundResults.Where(x => x.FundManager == manager));
        }

    }
}