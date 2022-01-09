using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.Requests.Location
{
    public class GetLocationsByCountryAndCityRequestValidator : AbstractValidator<GetLocationsByCountryAndCityRequest>
    {
        public GetLocationsByCountryAndCityRequestValidator()
        {
            RuleFor(x => x.CountryId).NotNull().NotEmpty();
            RuleFor(x => x.CityId).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<GetLocationsByCountryAndCityRequest> context, ValidationResult result)
        {
            if (context.InstanceToValidate is null)
            {
                result.Errors.Add(new ValidationFailure("", "Request parameter is null."));
                return false;
            }

            return true;
        }
    }
}
