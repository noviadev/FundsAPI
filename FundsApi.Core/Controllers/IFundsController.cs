using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace FundsApi.Core.Controllers
{
    public interface IFundsController
    {
        IActionResult GetFunds(string id);
        IActionResult GetManagerFunds(string manager);
    }
}
