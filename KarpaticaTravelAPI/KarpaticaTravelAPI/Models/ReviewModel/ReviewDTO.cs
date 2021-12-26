using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Models.ReviewModel
{
    public class ReviewDTO
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid LocationId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Rating { get; set; }
    }
}
