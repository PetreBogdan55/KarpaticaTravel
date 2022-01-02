using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.Requests.Review
{
    public class CreateReviewRequestValidator : AbstractValidator<CreateReviewRequest>
    {
        public CreateReviewRequestValidator()
        {
            RuleFor(x => x.ReviewDTO).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<CreateReviewRequest> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Request parameter is null."));
                return false;
            }
            return true;
        }
    }
}
