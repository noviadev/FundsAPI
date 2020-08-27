using System.Collections.Generic;
using Api.Common;

namespace Api.Models
{
    public interface IFundsProvider
    {
        List<FundsProperties> GetFunds();
    }
}
