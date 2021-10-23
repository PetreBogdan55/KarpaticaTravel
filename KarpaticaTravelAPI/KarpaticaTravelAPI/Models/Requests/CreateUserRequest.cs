using KarpaticaTravelAPI.Models.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests
{
    public class CreateUserRequest
    {
        [FromBody]
        public UserDto UserDto { get; set; }

    }
}

