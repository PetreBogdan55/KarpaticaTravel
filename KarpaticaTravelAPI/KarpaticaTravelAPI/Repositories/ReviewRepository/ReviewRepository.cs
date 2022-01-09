using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.ReviewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {
        public KarpaticaTravelContext _context;


        public ReviewRepository(KarpaticaTravelContext context)
        {
            _context = context;
        }

        public async Task<Review> CreateReview(Review review)
        {
            await _context.Review.AddAsync(review).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return review;
        }

        public async Task<bool> DeleteReview(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            var review = await _context.Review.FindAsync(id);

            if (review == null)
            {
                return false;
            }

            _context.Review.Remove(review);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Review>> GetReviewsByUser(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            IEnumerable<Review> reviews = await _context.Review.Where(b => b.UserId == id).ToListAsync();

            return reviews;
        }

        public async Task<IEnumerable<Review>> GetReviews()
        {
            return await _context.Review.ToListAsync();
        }

        public async Task<bool> UpdateReview(Guid id, Review review)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            if (id != review.Id)
            {
                return false;
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Review.Any(e => e.Id == id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<IEnumerable<Review>> GetReviewsByLocation(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            var reviews = await _context.Review.Where(b => b.LocationId == id).ToListAsync();

            return reviews;

        }

    }
}