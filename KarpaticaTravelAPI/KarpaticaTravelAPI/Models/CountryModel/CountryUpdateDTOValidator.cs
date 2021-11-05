using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.CountryModel
{
    public class CountryUpdateDTOValidator : AbstractValidator<CountryUpdateDTO>
    {
        public CountryUpdateDTOValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.CountryCode).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<CountryUpdateDTO> context, ValidationResult result)
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
