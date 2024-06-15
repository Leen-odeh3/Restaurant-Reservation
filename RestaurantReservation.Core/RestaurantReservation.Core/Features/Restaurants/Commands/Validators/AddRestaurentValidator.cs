using FluentValidation;
using RestaurantReservation.Core.Features.Restaurants.Commands.Models;

namespace RestaurantReservation.Core.Features.Restaurants.Commands.Validators
{
    public class AddRestaurantValidator : AbstractValidator<AddRestaurantCommand>
    {
        public AddRestaurantValidator()
        {
            ApplyValidationRules();
        }

        private void ApplyValidationRules()
        {
            RuleFor(x => x.RestaurantName)
                .NotEmpty().WithMessage("Restaurant name is required.")
                .MaximumLength(15).WithMessage("Restaurant name cannot exceed 15 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(40).WithMessage("Address cannot exceed 40 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(18).WithMessage("Phone number cannot exceed 18 characters.");

            RuleFor(x => x.OperatingHours)
                .NotEmpty().WithMessage("Operating hours are required.");
        }
    }
}
