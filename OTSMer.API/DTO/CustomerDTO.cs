using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTSMer.API.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int MarketId { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public int UserId { get; set; }
    }
}
