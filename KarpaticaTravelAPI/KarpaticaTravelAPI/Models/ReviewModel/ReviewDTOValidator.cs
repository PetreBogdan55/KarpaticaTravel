using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.ReviewModel
{
    public class ReviewDTOValidator : AbstractValidator<ReviewDTO>
    {
        public ReviewDTOValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.LocationId).NotNull().NotEmpty();
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.Rating).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<ReviewDTO> context, ValidationResult result)
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