using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class FundDetailsDto
    {
        public bool Active { get; set; }
        public decimal CurrentUnitPrice { get; set; }
        public string FundManager { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
