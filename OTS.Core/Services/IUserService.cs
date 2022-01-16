using OTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User newuser);
        Task UpdateUser(User userToBeUpdated, User user);
        Task DeleteUser(User user);

        User GetUserLogin(string username, string password);
    }
}
