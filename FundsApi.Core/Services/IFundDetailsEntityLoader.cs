using System;
using System.Collections.Generic;
using System.Text;
using FundsApi.Core.Entities;

namespace FundsApi.Core.Services
{
    public interface IFundDetailsEntityLoader
    {
        IList<IFundDetailsEntity> Load();
    }
}
