using Microsoft.AspNetCore.Mvc;
using System;

namespace KarpaticaTravelAPI.Models.Requests.User
{
    public class GetUserRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

    }
}

