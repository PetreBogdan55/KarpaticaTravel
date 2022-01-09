using KarpaticaTravelAPI.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.UserProcessor
{
    public interface IUserProcessor
    {
        Task<bool> CreateUser(UserDTO user);
        Task<bool> DeleteUser(Guid userId);
        Task<UserDTO> GetUser(Guid id);
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<LoginUserResult> LoginUser(string email, string password);
        Task<bool> UpdateUser(Guid id, UserUpdateDTO userToUpdate);
    }
}