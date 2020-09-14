using System;
using System.Collections.Generic;
using System.Text;
using FundsApi.Core.Entities.Interfaces;
using FundsApi.Core.Repositories;

namespace FundsApi.Core.Entities
{
    public class FundDetailsEntity : IFundDetailsEntity
    {
        public string Code { get; set; }
        public bool Active { get; set; }
        public string FundManager { get; set; }
        public string Name { get; set; }
        public decimal CurrentUnitPrice { get; set; }
    }
}
