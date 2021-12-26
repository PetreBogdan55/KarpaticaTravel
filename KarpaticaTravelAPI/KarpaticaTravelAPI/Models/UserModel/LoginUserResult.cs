
using System;

namespace KarpaticaTravelAPI.Models.UserModel
{
    public class LoginUserResult
    {
        public Guid Id { get; set; }
        
        public string Email { get; set; }

        public string Token { get; set; }

        public string Username{ get; set; }

    }
}