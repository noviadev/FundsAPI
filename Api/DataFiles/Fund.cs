using Api.DataFiles;

namespace Api
{
    public class Fund
    {
        public bool Active { get; set; }

        public decimal CurrentUnitPrice { get; set; }

        public string FundManager { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public Fund(FundDetails fundDetails)
        {
            this.Active = fundDetails.Active;
            this.CurrentUnitPrice = decimal.Round(fundDetails.CurrentUnitPrice, 2);
            this.FundManager = fundDetails.FundManager;
            this.Name = fundDetails.Name;
            this.Code = fundDetails.MarketCode;
            this.Active = fundDetails.Active;

        }
    }
}