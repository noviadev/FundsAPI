using System.Collections.Generic;
using FundsApi.Core.Entities;
using FundsApi.Core.Entities.Interfaces;
using FundsApi.Core.Repositories;
using FundsApi.Core.Services;
using FundsApi.Core.Services.Transformers;

namespace FundsApi.BusinessLogic.Common.Services
{
    public class FundDetailsEntityLoaderService : IFundDetailsEntityLoader
    {
        private readonly IFundDetailsRepository _fundDetailsRepository;
        private readonly IFundDetailsToFundDetailsEntityTransformer _fundDetailsToFundDetailsEntityTransformer;

        public FundDetailsEntityLoaderService(IFundDetailsRepository fundDetailsRepository,
            IFundDetailsToFundDetailsEntityTransformer fundDetailsToFundDetailsEntityTransformer)
        {
            _fundDetailsRepository = fundDetailsRepository;
            _fundDetailsToFundDetailsEntityTransformer = fundDetailsToFundDetailsEntityTransformer;
        }

        public IList<IFundDetailsEntity> Load()
        {
            var entities = _fundDetailsRepository.All();
            var transformedEntities = _fundDetailsToFundDetailsEntityTransformer.Transform(entities);
            return transformedEntities;
        }
    }
}