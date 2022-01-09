using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.Requests.Review
{
    public class UpdateReviewRequestValidator : AbstractValidator<UpdateReviewRequest>
    {
        public UpdateReviewRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.ReviewUpdateDTO).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<UpdateReviewRequest> context, ValidationResult result)
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
