using System.Collections.Generic;
using Api.Models;
using Api.Utilities;

namespace Api.Converter {
    public class ConvertToPublic: IConverterToPublic {
        private readonly IMathsUtilities _mathsUtilities;
        
        public ConvertToPublic(IMathsUtilities mathsUtilities) {
            _mathsUtilities = mathsUtilities;
        }

        public List<FundDetailsPublic> ConvertFundsToPublicView(List<FundDetails> funds) {
            List<FundDetailsPublic> fundsPublic = new List<FundDetailsPublic>();

            foreach (FundDetails fund in funds) {
                FundDetailsPublic fundPublic = new FundDetailsPublic {
                    Active = fund.Active,
                    CurrentUnitPrice = _mathsUtilities.RoundAmount(fund.CurrentUnitPrice),
                    FundManager = fund.FundManager,
                    Name = fund.Name,
                    Code = fund.MarketCode
                };

                fundsPublic.Add(fundPublic);
            }
            return fundsPublic;
        }
    }
}
