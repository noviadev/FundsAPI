using System.Collections.Generic;
using Api.Common;
using Api.Models;
using Api.Utilities;
using Api.ViewModels;
using AutoMapper;
using DataReader.JSON;

namespace Api.Controllers
{
    using Microsoft.Extensions.Logging;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    public class FundsController : Controller
    {
        private readonly ILogger<FundsController> _logger;
        private readonly IFundsProvider _fundsProvider;

        private string FilePath { get; } = "./DataFiles/";
        private string FileName { get; } = "funds.json";


        public FundsController(ILogger<FundsController> logger = null)
        {
            //Here we define which type of data we'll use for the abstraction, in this case it's in the higher level of
            //dependency injection. Normally I would pass just the dependency through the overload and define the type of data
            //on a higher level.
            _fundsProvider = new JSONReader(FilePath, FileName);
            _logger = logger;
        }


        [Route("get-funds")]
        public IActionResult GetFunds()
        {
            
            var funds = _fundsProvider.GetFunds();

            if (funds.Count > 0)
            {
                _logger.LogInformation("HTTP OK: Funds Found");
                return Ok(FundsViewModelAutomapping(funds));
            }

            _logger.LogWarning("HTTP Not found: No Funds Found");
            return NotFound("No funds available");

        }

        [Route("get-fund/{marketCode}")]
        public IActionResult GetSingleFund(string marketCode)
        {
            
            var fund = _fundsProvider.GetFunds().FirstOrDefault(x => x.MarketCode == marketCode);

            if (fund != null)
            {
                _logger.LogInformation("HTTP OK: Single Fund Found");
                return Ok(SingleFundAutomapping(fund));
            }

            _logger.LogWarning("HTTP Not found: No Fund Found");
            return NotFound("Fund not found");
            
        }


        [Route("get-managerfunds/{manager}")]
        public IActionResult GetManagerFunds(string manager)
        {
            
            var funds = _fundsProvider.GetFunds().Where(x => x.FundManager == manager);

            if (funds.Any())
            {
                _logger.LogInformation("HTTP OK: Manager Fund Found");
                return Ok(FundsViewModelAutomapping(funds));
            }

            _logger.LogWarning("HTTP Not found: No Manager Fund Found");
            return NotFound("Manager funds not found");
        }


        #region [FUNDS VIEWMODEL AUTOMAPPING]

        private List<FundsViewModel> FundsViewModelAutomapping(IEnumerable<FundsProperties> fundsProperties)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FundsProperties, FundsViewModel>().ForMember(destination => destination.Code, opts => opts.MapFrom(source => source.MarketCode));
            });

            var iMapper = config.CreateMapper();

            var fundsList = new List<FundsViewModel>();

            foreach (var fund in fundsProperties)
            {
                //Each unit is converted to two digital places
                fund.CurrentUnitPrice = StaticMethods.RoundNumbers(fund.CurrentUnitPrice);

                var mappedData = iMapper.Map<FundsProperties, FundsViewModel>(fund);

                fundsList.Add(mappedData);

            }

            return fundsList;
        }

        private FundsViewModel SingleFundAutomapping(FundsProperties fundProperties)
        {
            //Unit converted to two digital places
            fundProperties.CurrentUnitPrice = StaticMethods.RoundNumbers(fundProperties.CurrentUnitPrice);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FundsProperties, FundsViewModel>().ForMember(destination => destination.Code, opts => opts.MapFrom(source => source.MarketCode));
            });

            var iMapper = config.CreateMapper();

            return iMapper.Map<FundsProperties, FundsViewModel>(fundProperties);
        }

        #endregion

    }
}