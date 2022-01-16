using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTSMer.API.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ImageUrl { get; set; }

        public bool IsActive { get; set; }
    }
}
