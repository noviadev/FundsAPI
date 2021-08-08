using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.LogMessage;
using Api.DataAccess;
using Api.Converter;
using Api.Utilities;

namespace Api.Controllers {

    public class FundsController : Controller {
        private readonly ILogMessage _logMessage;
        private readonly IDataAccess _dataAccess;
        private readonly ConvertToPublic _converter;

        public FundsController(ILogMessage logMessage, IDataAccess dataAccess, IMathsUtilities mathsUtilities) {
            _logMessage = logMessage;
            _dataAccess = dataAccess;
            _converter = new ConvertToPublic(mathsUtilities);
        }

        [HttpGet]
        [Route("get-funds")]
        [Route("get-funds/{id}")]
        public IActionResult GetFunds(string id) {
            _logMessage.WriteToLog(string.IsNullOrEmpty(id) ? "All funds" : "Fund MarketCode = " + id);

            List<FundDetailsPublic> funds = _converter.ConvertFundsToPublicView(_dataAccess.GetData());

            // Return all funds
            if (id == null) return this.Ok(funds);

            // Return matching funds
            try {
                return this.Ok(funds.Single(x => x.Code == id));
            } catch (InvalidOperationException ex) {
                // No matching funds found
                return this.NoContent();
            }
        }

        [HttpGet]
        [Route("get-managerfunds")]
        [Route("get-managerfunds/{manager}")]
        public IActionResult GetManagerFunds(string manager) {
            _logMessage.WriteToLog("FundManager = " + manager);

            List<FundDetailsPublic> funds = _converter.ConvertFundsToPublicView(_dataAccess.GetData()).Where(x => x.FundManager == manager).ToList();

            // Return matching funds
            if (funds.Count == 0)  return this.NoContent();

            return this.Ok(funds);
        }
    }
}