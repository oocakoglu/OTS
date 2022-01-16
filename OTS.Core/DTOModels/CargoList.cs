using System;
using System.Collections.Generic;
using System.Text;

namespace OTS.Core.DTOModels
{
    public class CargoList 
    {
        public int CargoId { get; set; }

        public string CargoName { get; set; }

        public string CargoImageUrl { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}
