using KarpaticaTravelAPI.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<bool> DeleteUser(Guid id);
        Task<User> GetUser(Guid id);
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> UpdateUser(Guid id, User user);
    }
}