using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.Requests.Review
{
    public class GetReviewRequestValidator : AbstractValidator<GetReviewRequest>
    {
        public GetReviewRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<GetReviewRequest> context, ValidationResult result)
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
