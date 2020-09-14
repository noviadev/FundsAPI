using System;
using System.Collections.Generic;
using System.Text;
using FundsApi.Core.Entities;
using FundsApi.Core.Entities.Interfaces;

namespace FundsApi.Core.Services.Transformers
{
    public interface IFundDetailsToFundDetailsEntityTransformer
    {
        IList<IFundDetailsEntity> Transform(IList<FundDetails> sources);
        IFundDetailsEntity Transform(FundDetails source);
    }
}
