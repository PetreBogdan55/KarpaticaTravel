using KarpaticaTravelAPI.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KarpaticaTravelAPI.Models.Requests.User
{
    public class LoginUserRequest
    {
        [FromBody]
        public LoginUser LoginUser { get; set; }

    }
}

