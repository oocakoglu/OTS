using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OTS.Model
{
    public class User : IEntity
    {
        public User()
        {
            Markets = new Collection<Market>();
        }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ImageUrl { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Market> Markets { get; set; }

    }
}
