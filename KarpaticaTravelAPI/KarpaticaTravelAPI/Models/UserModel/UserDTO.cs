
using System;

namespace KarpaticaTravelAPI.Models.UserModel
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        //public string Salt { get; set; }

        public string Phone { get; set; }

        // public bool IsOwner { get; set; }

    }
}