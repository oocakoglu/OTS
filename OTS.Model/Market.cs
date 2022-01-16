using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OTS.Model
{
    public class Market : IEntity
    {
        public int MarketId { get; set; }

        public string MarketName { get; set; }

        public string Commision { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

    }
}
