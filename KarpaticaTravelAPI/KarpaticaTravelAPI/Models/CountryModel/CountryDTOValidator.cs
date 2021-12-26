using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.CountryModel
{
    public class CountryDTOValidator : AbstractValidator<CountryDTO>
    {
        public CountryDTOValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.CountryCode).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<CountryDTO> context, ValidationResult result)
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
