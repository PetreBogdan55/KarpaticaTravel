using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Models.Requests.Location
{
    public class GetLocationsByActivityRequestValidator : AbstractValidator<GetLocationsByActivityRequest>
    {
        public GetLocationsByActivityRequestValidator()
        {
            RuleFor(x => x.ActivityId).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<GetLocationsByActivityRequest> context, ValidationResult result)
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
