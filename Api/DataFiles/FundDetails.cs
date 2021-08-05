using Api.Helpers;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.DataFiles
{
    public class FundDetails
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public bool Active { get; set; }

        [JsonConverter(typeof(DecimalConverter))]
        public decimal CurrentUnitPrice { get; set; }

        public string FundManager { get; set; }

        public string Name { get; set; }

        public virtual string MarketCode { get; set; }
    }
}