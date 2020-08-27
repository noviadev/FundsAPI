using System;

namespace Api.Common
{
    public class FundsProperties
    {
        public Guid Id { get; set; }

        public bool Active { get; set; }

        public decimal CurrentUnitPrice { get; set; }

        public string FundManager { get; set; }

        public string Name { get; set; }

        public string MarketCode { get; set; }
    }
}
