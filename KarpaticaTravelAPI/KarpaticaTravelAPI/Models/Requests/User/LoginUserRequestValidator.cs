using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.Requests.User
{
    public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator()
        {
            RuleFor(x => x.LoginUser).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<LoginUserRequest> context, ValidationResult result)
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
