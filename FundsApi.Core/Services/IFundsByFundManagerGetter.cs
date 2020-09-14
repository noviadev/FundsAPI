using System;
using System.Collections.Generic;
using System.Text;
using FundsApi.Core.Entities.Interfaces;

namespace FundsApi.Core.Services
{
    public interface IFundsByFundManagerGetter
    {
         IList<IFundDetailsEntity> GetFunds(string fundManager);
    }
}
