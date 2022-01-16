using System;
using System.Collections.Generic;
using System.Text;

namespace OTS.Core.DTOModels
{
    public class CustomerList 
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public int UserId { get; set; }
        public int MarketId { get; set; }

        public string UserName { get; set; }
        public string MarketName { get; set; }
    }
}
