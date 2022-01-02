using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.Requests.Location
{
    public class CreateLocationRequestValidator: AbstractValidator<CreateLocationRequest>
    {
        public CreateLocationRequestValidator()
        {
            RuleFor(x => x.LocationDTO).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<CreateLocationRequest> context, ValidationResult result)
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
