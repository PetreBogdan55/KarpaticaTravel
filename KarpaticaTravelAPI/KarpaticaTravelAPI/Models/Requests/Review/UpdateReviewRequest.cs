using KarpaticaTravelAPI.Models.ReviewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KarpaticaTravelAPI.Models.Requests.Review
{
    public class UpdateReviewRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromBody]
        public ReviewUpdateDTO ReviewUpdateDTO{ get; set; }
    }
}

