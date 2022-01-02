using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace KarpaticaTravelAPI.Models.LocationModel
{
    public class LocationDTOValidator : AbstractValidator<LocationDTO>
    {
        public LocationDTOValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.ActivityId).NotNull().NotEmpty();
            RuleFor(x => x.Address).NotNull().NotEmpty();
            RuleFor(x => x.CityId).NotNull().NotEmpty();
            RuleFor(x => x.DistanceFromCenter).NotNull().NotEmpty();
            RuleFor(x => x.IsAvailable).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.OwnerId).NotNull().NotEmpty();
            RuleFor(x => x.PricePerDay).NotNull().NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<LocationDTO> context, ValidationResult result)
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
