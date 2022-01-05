using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Controllers;
using KarpaticaTravelAPI.Models.ReviewModel;
using KarpaticaTravelAPI.Processors.ReviewProcessor;
using System.Net;
using KarpaticaTravelAPI.Models.Requests.Review;
using FluentValidation;

namespace KarpaticaTravelAPI.Controllers
{
    public class ReviewsController : BaseController
    {
        private readonly IReviewProcessor _reviewProcessor;

        public ReviewsController(IReviewProcessor reviewRepository)
        {
            _reviewProcessor = reviewRepository;
        }


        [ProducesResponseType(typeof(IEnumerable<ReviewDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetReviewsAsync()
        {
            IEnumerable<ReviewDTO> result = await _reviewProcessor.GetReviews().ConfigureAwait(false);

            if (result == null)
            {
                return NotFound("No reviews found.");
            }

            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<ReviewDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewsByUserAsync(GetReviewRequest request)
        {
            try
            {
                GetReviewRequestValidator rules = new GetReviewRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                IEnumerable<ReviewDTO> result = await _reviewProcessor.GetReviewsByUser(request.Id).ConfigureAwait(false);

                if (result == null)
                {
                    return NotFound("No reviews found.");
                }

                return Ok(result);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviewAsync(UpdateReviewRequest request)
        {
            try
            {
                UpdateReviewRequestValidator rules = new UpdateReviewRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                if (!await _reviewProcessor.UpdateReview(request.Id, request.ReviewUpdateDTO).ConfigureAwait(false))
                {
                    return BadRequest();
                }

                return NoContent();
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostReviewAsync(CreateReviewRequest request)
        {
            try
            {
                CreateReviewRequestValidator rules = new CreateReviewRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                bool isCreated = await _reviewProcessor.CreateReview(request.ReviewDTO).ConfigureAwait(false);

                if (!isCreated)
                {
                    return BadRequest(isCreated);
                }

                return Ok(isCreated);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewAsync(DeleteReviewRequest request)
        {
            try
            {
                DeleteReviewRequestValidator rules = new DeleteReviewRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                bool result = await _reviewProcessor.DeleteReview(request.Id).ConfigureAwait(false);

                if (!result)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}