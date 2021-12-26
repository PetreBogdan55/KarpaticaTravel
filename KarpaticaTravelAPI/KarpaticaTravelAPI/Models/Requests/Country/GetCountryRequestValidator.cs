using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.Requests.Country
{
    public class GetCountryRequestValidator : AbstractValidator<GetCountryRequest>
    {
        public GetCountryRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<GetCountryRequest> context, ValidationResult result)
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
