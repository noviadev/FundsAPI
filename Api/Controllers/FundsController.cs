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
    using Microsoft.Extensions.Logging;
    using Api.DAO;
    using Api.Interfaces;

    public class FundsController : Controller
    {
        private ILogger<FundsController> _logger { get; }
        private IFundsDAO _fundsDAO;

        public FundsController(ILogger<FundsController> logger, IFundsDAO fundsDAO)
        {
            _logger = logger;
            _fundsDAO = fundsDAO;
        }

        [HttpGet]
        [Route("get-funds")]
        [Route("get-funds/{id}")]
        public IActionResult GetFunds(string id)
        {
            //Either Retrieve all funds or
            //Retrieve a single fund identified by its MarketCode (id is matched with MarketCode property)

            _logger.LogInformation(string.Format("GetFunds id={0}", id));

            List<FundDetailsOutput> funds = _fundsDAO.GetFundsData();

            if (id != null)
            {
                try
                {
                    return this.Ok(funds.Single(x => x.MarketCode == id));
                }
                catch (InvalidOperationException ex)
                {
                    //There was no matching fund to return for the input
                    return this.NotFound();
                }
            }

            return this.Ok(funds);
        }

        [HttpGet]
        [Route("get-managerfunds")]
        [Route("get-managerfunds/{manager}")]
        public IActionResult GetManagerFunds(string manager)
        {
            //Retrieve all Funds from a given Fund Manager.

            _logger.LogInformation(string.Format("GetManagerFunds manager={0}", manager));

            List<FundDetailsOutput> funds = _fundsDAO.GetFundsData();

            if (manager != null)
            {
                var foundFunds = funds.Where(x => x.FundManager == manager).ToList();
                if (foundFunds.Count > 0) return this.Ok(foundFunds);
            }
            
            return this.NotFound();
            
        }
    }
}