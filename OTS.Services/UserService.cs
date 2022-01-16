using OTS.Core;
using OTS.Model;
using OTS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async  Task<User> CreateUser(User newuser)
        {
            newuser.IsActive = true;
            await _unitOfWork.Users.AddAsync(newuser);
            await _unitOfWork.CommitAsync();
            return newuser;
        }

        public async Task DeleteUser(User user)
        {
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task UpdateUser(User userToBeUpdated, User user)
        {
            userToBeUpdated.UserName = user.UserName;
            userToBeUpdated.Password = user.Password;
            userToBeUpdated.ImageUrl = user.ImageUrl;
            userToBeUpdated.IsActive = user.IsActive;
            await _unitOfWork.CommitAsync();
        }

        public  User GetUserLogin(string username, string password)
        {
            return _unitOfWork.Users.GetUserWithUserNamePassord(username, password);
        }
    }
}
