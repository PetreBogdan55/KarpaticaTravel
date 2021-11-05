using KarpaticaTravelAPI.Models.UserModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> UpdateUser(int id, User user);
    }
}