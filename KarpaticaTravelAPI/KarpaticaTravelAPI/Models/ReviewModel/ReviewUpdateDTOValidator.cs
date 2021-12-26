using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.ReviewModel
{
    public class ReviewUpdateDTOValidator : AbstractValidator<ReviewUpdateDTO>
    {
        public ReviewUpdateDTOValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.Rating).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<ReviewUpdateDTO> context, ValidationResult result)
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