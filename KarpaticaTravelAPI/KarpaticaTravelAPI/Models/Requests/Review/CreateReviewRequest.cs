using KarpaticaTravelAPI.Models.ReviewModel;
using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.Review
{
    public class CreateReviewRequest
    {
        [FromBody]
        public ReviewDTO ReviewDTO{ get; set; }

    }
}