using KarpaticaTravelAPI.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KarpaticaTravelAPI.Models.Requests.User
{
    public class UpdateUserRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromBody]
        public UserUpdateDTO UserUpdateDTO { get; set; }
    }
}

