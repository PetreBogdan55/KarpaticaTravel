using KarpaticaTravelAPI.Models.ReviewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.ReviewProcessor
{
    public interface IReviewProcessor
    {
        Task<bool> CreateReview(ReviewDTO review);
        Task<bool> DeleteReview(Guid reviewId);
        Task<IEnumerable<ReviewDTO>> GetReviewsByUser(Guid id);
        Task<IEnumerable<ReviewDTO>> GetReviews();
        Task<bool> UpdateReview(Guid id, ReviewUpdateDTO reviewToUpdate);
    }
}