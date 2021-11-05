using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.User
{
    public class DeleteUserRequest
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }

    }
}

