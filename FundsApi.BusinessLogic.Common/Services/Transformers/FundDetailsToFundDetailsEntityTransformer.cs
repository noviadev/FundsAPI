using System;
using System.Collections.Generic;
using FundsApi.Core.Entities;
using FundsApi.Core.Entities.Interfaces;
using FundsApi.Core.Services.Transformers;

namespace FundsApi.BusinessLogic.Common.Services.Transformers
{
    public class FundDetailsToFundDetailsEntityTransformer : IFundDetailsToFundDetailsEntityTransformer
    {
        public IList<IFundDetailsEntity> Transform(IList<FundDetails> sources)
        {
            var targets = new List<IFundDetailsEntity>();
            foreach (var source in sources)
            {
                var target = Transform(source);
                targets.Add(target);
            }
            return targets;
        }

        public IFundDetailsEntity Transform(FundDetails source)
        {
            return new FundDetailsEntity()
            {
                Name = source.Name,
                Active = source.Active,
                Code = source.MarketCode,
                CurrentUnitPrice = Decimal.Round(source.CurrentUnitPrice),
                FundManager = source.FundManager
            };
        }
    }
}