using System.Collections.Generic;
using FundsApi.Core.Entities;

namespace FundsApi.Core.Repositories
{
    public interface IFundDetailsRepository
    {
        IList<FundDetails> All();
    }
}
