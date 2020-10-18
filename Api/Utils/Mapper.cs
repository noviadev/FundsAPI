using Api.Interfaces;
using System;
using System.Collections.Generic;
using Api.DataFiles;

namespace Api.Utils
{
    public class Mapper : IMapper
    {
        // NOTES ***************************************************
        //
        // This classed is used for mapping the source data objects
        // to the formatted objects expected by the consumer as per
        // the user story. So - id field should not be exposed; the
        // currentUnitPrice price field should be rounded to 2 dp;
        // marketCode field should be exposed as code field. Also,
        // worth nothing that the consumer has not specified HOW to
        // round, so if this was real I would be asking that question
        // for sure, because there are many different ways we can
        // round, especially when dealing with financials.....
        // *********************************************************

        // Public methods
        public List<FundDetails> MapFunds(List<FundDetailsDTO> fundsDTO)
        {
            List<FundDetails> funds = new List<FundDetails>();

            foreach (FundDetailsDTO fundDTO in fundsDTO)
            {
                // Round the unit price. I have used Math.Round for simplicity here,
                // as no specific intructions on how to round were provided...
                decimal currUnitPrice = Math.Round(fundDTO.CurrentUnitPrice, 2);

                // Map the new object from DTO
                FundDetails fund = new FundDetails
                {
                    Active = fundDTO.Active,
                    CurrentUnitPrice = currUnitPrice,
                    FundManager = fundDTO.FundManager,
                    Name = fundDTO.Name,
                    Code = fundDTO.MarketCode
                };

                // Add to list
                funds.Add(fund);
            }

            return funds;
        }
    }
}