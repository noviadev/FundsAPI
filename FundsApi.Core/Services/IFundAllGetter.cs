using System.Collections.Generic;
using FundsApi.Core.Entities.Interfaces;

namespace FundsApi.Core.Services
{
    public interface IFundAllGetter
    {
        IList<IFundDetailsEntity> GetAll();
    }
}