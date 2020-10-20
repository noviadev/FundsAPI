using Newtonsoft.Json;
using System;

namespace Api.DataFiles
{
    public class FundDetails
    {
        private decimal _currentUnitPrice;

        private Guid Id { get; set; }

        public bool Active { get; set; }

        public decimal CurrentUnitPrice {
            get
            {
                return decimal.Round(_currentUnitPrice, 2);
            }
            set
            {
                _currentUnitPrice = value;
            }
        }

        public string FundManager { get; set; }

        public string Name { get; set; }

        [JsonProperty("marketCode")]
        public string Code { get; set; }
    }
}
