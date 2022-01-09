using KarpaticaTravelAPI.Models.UserModel;
using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.User
{
    public class CreateUserRequest
    {
        [FromBody]
        public UserDTO UserDTO { get; set; }

    }
}

