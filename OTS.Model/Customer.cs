using System;
using System.Collections.Generic;
using System.Text;

namespace OTS.Model
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }  
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public int UserId { get; set; }    
        public int MarketId { get; set; }

    }
}
