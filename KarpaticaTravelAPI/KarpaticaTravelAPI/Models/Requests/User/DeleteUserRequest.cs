using Microsoft.AspNetCore.Mvc;
using System;

namespace KarpaticaTravelAPI.Models.Requests.User
{
    public class DeleteUserRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

    }
}

