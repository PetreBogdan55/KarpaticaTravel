using KarpaticaTravelAPI.Models.UserModel;
using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.User
{
    public class UpdateUserRequest
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }

        [FromBody]
        public UserUpdateDTO UserUpdateDTO { get; set; }
    }
}

