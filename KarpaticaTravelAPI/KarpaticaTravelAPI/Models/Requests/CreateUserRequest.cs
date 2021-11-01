using KarpaticaTravelAPI.Models.UserModel;
using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests
{
    public class CreateUserRequest
    {
        [FromBody]
        public UserDTO UserDTO { get; set; }

    }
}

