using OTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Core.Repositories
{
    public interface  IUserRepository : IRepository<User>
    {
        //Task<IEnumerable<User>> GetAllWithCustomersAsync();

        //Task<User> GetWithCustomerIdAsync(int id);

        User GetUserWithUserNamePassord(string username, string password);
    }



}
