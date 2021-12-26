using Microsoft.AspNetCore.Mvc;
using System;

namespace KarpaticaTravelAPI.Models.Requests.Review
{
    public class DeleteReviewRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

    }
}

