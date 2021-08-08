using System.Collections.Generic;
using Api.Models;

namespace Api.Converter {
    public interface IConverterToPublic {
        List<FundDetailsPublic> ConvertFundsToPublicView(List<FundDetails> funds);

    }
}
