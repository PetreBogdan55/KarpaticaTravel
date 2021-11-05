using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.User
{
    public class GetUserRequest
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }

    }
}

