using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DataFiles
{
    public class FundDetailsOutput : FundDetails
    {
        //Override the class property
        //so that we can return Code as the JSON name in the response
        //The base class can't have the json property as it needs to deserialize with marketCode as the name

        [JsonProperty("Code")]
        public override string MarketCode { get; set; }
    }
}
