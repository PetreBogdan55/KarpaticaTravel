using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using KarpaticaTravelAPI.Models.Requests.Review;

namespace KarpaticaTravelAPI.Models.Requests.Booking
{
    public class GetBookingsRequestValidator : AbstractValidator<GetBookingsRequest>
    {
        public GetBookingsRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<GetBookingsRequest> context, ValidationResult result)
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
