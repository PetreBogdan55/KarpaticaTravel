using KarpaticaTravelAPI.Models.UserModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.UserProcessor
{
    public interface IUserProcessor
    {
        Task<bool> CreateUser(UserDTO user);
        Task<bool> DeleteUser(int userId);
        Task<UserDTO> GetUser(int id);
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<bool> UpdateUser(int id, UserUpdateDTO userToUpdate);
    }
}