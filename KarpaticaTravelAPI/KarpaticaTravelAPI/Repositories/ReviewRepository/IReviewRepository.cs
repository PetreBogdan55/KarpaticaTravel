using KarpaticaTravelAPI.Models.ReviewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories.ReviewRepository
{
    public interface IReviewRepository
    {
        Task<Review> CreateReview(Review review);
        Task<bool> DeleteReview(Guid id);
        Task<IEnumerable<Review>> GetReviewsByUser(Guid id);
        Task<IEnumerable<Review>> GetReviewsByLocation(Guid id);
        Task<IEnumerable<Review>> GetReviews();
        Task<bool> UpdateReview(Guid id, Review review);
    }
}