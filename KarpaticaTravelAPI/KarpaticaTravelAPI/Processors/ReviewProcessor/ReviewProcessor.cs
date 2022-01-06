using AutoMapper;
using FluentValidation;
using KarpaticaTravelAPI.Models.ReviewModel;
using KarpaticaTravelAPI.Repositories.ReviewRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.ReviewProcessor
{
    public class ReviewProcessor : IReviewProcessor
    {

        private IReviewRepository _reviewRepository;
        private IMapper _mapper;

        public ReviewProcessor(IReviewRepository repository, IMapper mapper)
        {
            _reviewRepository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateReview(ReviewDTO review)
        {
            try
            {
                ReviewDTOValidator rules = new ReviewDTOValidator();
                await rules.ValidateAndThrowAsync(review).ConfigureAwait(false);

                Review newReview = _mapper.Map<ReviewDTO, Review>(review);

                if (review.Id == Guid.Empty)
                {
                    newReview.Id = Guid.NewGuid();

                }

                await _reviewRepository.CreateReview(newReview).ConfigureAwait(false);

                return true;
            }
            catch (ValidationException validationException)
            {
                Console.WriteLine(validationException.Message);
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<bool> DeleteReview(Guid reviewId)
        {
            try
            {
                return await _reviewRepository.DeleteReview(reviewId).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<IEnumerable<ReviewDTO>> GetReviews()
        {
            IEnumerable<Review> resultList = await _reviewRepository.GetReviews().ConfigureAwait(false);
            return new List<ReviewDTO>(_mapper.Map<IEnumerable<ReviewDTO>>(resultList));
        }

        public async Task<IEnumerable<ReviewDTO>> GetReviewsByUser(Guid id)
        {
            IEnumerable<Review> resultList = await _reviewRepository.GetReviewsByUser(id).ConfigureAwait(false);
            return new List<ReviewDTO>(_mapper.Map<IEnumerable<ReviewDTO>>(resultList));
        }

        public async Task<IEnumerable<ReviewDTO>> GetReviewsByLocation(Guid id)
        {
            IEnumerable<Review> resultList = await _reviewRepository.GetReviewsByLocation(id).ConfigureAwait(false);
            return new List<ReviewDTO>(_mapper.Map<IEnumerable<ReviewDTO>>(resultList));
        }

        public async Task<bool> UpdateReview(Guid id, ReviewUpdateDTO reviewToUpdate)
        {
            try
            {
                ReviewUpdateDTOValidator rules = new ReviewUpdateDTOValidator();
                await rules.ValidateAndThrowAsync(reviewToUpdate).ConfigureAwait(false);

                Review newReviewObject = _mapper.Map<ReviewUpdateDTO, Review>(reviewToUpdate);
                newReviewObject.Id = id;

                return await _reviewRepository.UpdateReview(id, newReviewObject).ConfigureAwait(false);
            }
            catch (ValidationException validationException)
            {
                Console.WriteLine(validationException.Message);
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}
