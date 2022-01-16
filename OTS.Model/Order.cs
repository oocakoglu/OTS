using System;
using System.Collections.Generic;
using System.Text;

namespace OTS.Model
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int MarketId { get; set; }
        public int CustomerId { get; set; }

        public string ProductName { get; set; }
        public string ProductCode { get; set; }

        public int Width { get; set; }
        public int Length { get; set; }

        public double M2 { get; set; }

        public string Description { get; set; }

    }
}
