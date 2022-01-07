using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.Requests.Booking
{
    public class CreateBookingRequestValidator : AbstractValidator<CreateBookingRequest>
    {
        public CreateBookingRequestValidator()
        {
            RuleFor(x => x.BookingDTO).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<CreateBookingRequest> context, ValidationResult result)
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
