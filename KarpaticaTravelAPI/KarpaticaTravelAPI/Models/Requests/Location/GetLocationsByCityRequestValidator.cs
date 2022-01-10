using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Models.Requests.Location
{
    public class GetLocationsByCityRequestValidator : AbstractValidator<GetLocationsByCityRequest>
    {
        public GetLocationsByCityRequestValidator()
        {
            RuleFor(x => x.CityId).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<GetLocationsByCityRequest> context, ValidationResult result)
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
