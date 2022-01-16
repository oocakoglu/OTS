using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTSMer.API.DTO
{
    public class CargoDTO
    {
        public int CargoId { get; set; }

        public string CargoName { get; set; }

        public string CargoImageUrl { get; set; }

        public int UserId { get; set; }
    }
}
