using FluentValidation;
using RestaurantReservation.Core.Features.Restaurants.Commands.Models;
using RestaurantReservation.Services.Abstracts;
using RestaurantReservation.Services.Implementations;

namespace RestaurantReservation.Core.Features.Restaurants.Commands.Validators
{
    public class EditRestaurantValidator : AbstractValidator<EditRestaurantCommand>
    {
        private readonly IRestaurantService _restaurantService;

        public EditRestaurantValidator(IRestaurantService restaurantService)
        {
            ApplyValidationRules();
            ApplyCustomValidationsRules();
            _restaurantService = restaurantService;
        }

        private void ApplyValidationRules()
        {
            RuleFor(x => x.RestaurantName)
                .NotEmpty().WithMessage("Restaurant name is required.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(18).WithMessage("Phone number cannot exceed 18 characters.");

            RuleFor(x => x.OperatingHours)
                .NotEmpty().WithMessage("Operating hours are required.");
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.RestaurantName)
                .MustAsync(async (model, name, cancellationToken) =>
                    !await _restaurantService.IsNameExist(name, model.Id))
                .WithMessage("Restaurant name must be unique.");
        }


    }
}
