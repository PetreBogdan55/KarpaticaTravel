using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.Requests.Country
{
    public class DeleteCountryRequestValidator : AbstractValidator<DeleteCountryRequest>
    {
        public DeleteCountryRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<DeleteCountryRequest> context, ValidationResult result)
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
