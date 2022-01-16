using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTSMer.API.DTO
{
    public class MarketDTO
    {
        public int MarketId { get; set; }

        public string MarketName { get; set; }

        public string Commision { get; set; }

        public int UserId { get; set; }
    }
}
