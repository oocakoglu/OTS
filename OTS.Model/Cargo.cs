using System;
using System.Collections.Generic;
using System.Text;

namespace OTS.Model
{
    public class Cargo : IEntity
    {
        public int CargoId { get; set; }

        public string CargoName { get; set; }

        public string CargoImageUrl { get; set; }

        public int UserId { get; set; }
    }
}
