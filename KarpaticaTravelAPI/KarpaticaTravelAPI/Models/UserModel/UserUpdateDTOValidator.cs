using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.UserModel
{
    public class UserUpdateDTOValidator : AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateDTOValidator()
        {
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.Phone).NotNull().NotEmpty();
            RuleFor(x => x.Username).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<UserUpdateDTO> context, ValidationResult result)
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