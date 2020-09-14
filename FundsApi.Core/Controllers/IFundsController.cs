using System;
using System.Collections.Generic;
using System.Text;
using FundsApi.Core.Entities;
using FundsApi.Core.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FundsApi.Core.Controllers
{
    public interface IFundsController
    {
        IActionResult GetFunds(string id);
        IActionResult GetManagerFunds(string manager);

        IActionResult GetFundByCode(string code);
        IActionResult GetAllFunds();
    }
}
