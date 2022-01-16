using OTS.Model;
using OTS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(OTSDbContext context) : base(context)
        {
        }


        private OTSDbContext OTSDbContext
        {
            get { return Context as OTSDbContext; }
        }

        public User GetUserWithUserNamePassord(string username, string password)
        {
            return OTSDbContext.Users.Where(q => q.UserName == username && q.Password == password).FirstOrDefault();
        }


        //public Task<IEnumerable<User>> GetAllWithCustomersAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<User> GetWithCustomerIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //    //return await OTSDbContext.Users.Where(q => q.UserId == id).FirstOrDefault();
        //}
    }
}
