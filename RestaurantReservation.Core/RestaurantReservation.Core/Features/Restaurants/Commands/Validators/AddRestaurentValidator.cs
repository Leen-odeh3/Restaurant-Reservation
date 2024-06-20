using FluentValidation;
using RestaurantReservation.Core.Features.Restaurants.Commands.Models;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.Restaurants.Commands.Validators
{
    public class AddRestaurantValidator : AbstractValidator<AddRestaurantCommand>
    {
        private readonly IRestaurantService _restaurantService;
        public AddRestaurantValidator(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
            ApplyValidationRules();
            ApplyCustomValidationsRules();
        }

        private void ApplyValidationRules()
        {
            RuleFor(x => x.RestaurantName)
                .NotEmpty().WithMessage("Restaurant name is required.")
                .MaximumLength(30).WithMessage("Restaurant name cannot exceed 30 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(40).WithMessage("Address cannot exceed 40 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(18).WithMessage("Phone number cannot exceed 18 characters.");

            RuleFor(x => x.OperatingHours)
                .NotEmpty().WithMessage("Operating hours are required.");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.RestaurantName)
                .MustAsync(async (Key, CancellationToken) => !await _restaurantService.IsRestaurantNameExist(Key))
                .WithMessage("RestaurantName already exists.");
            
        }
    }
}
