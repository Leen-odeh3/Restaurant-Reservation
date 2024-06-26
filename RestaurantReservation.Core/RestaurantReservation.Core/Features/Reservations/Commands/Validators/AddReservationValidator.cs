using FluentValidation;
using RestaurantReservation.Core.Features.OrderItems.Commands.Models;

namespace RestaurantReservation.Core.Features.OrderItems.Commands.Validators;

public class AddReservationValidator : AbstractValidator<AddOrderItemCommand>
{
    public AddReservationValidator()
    {
        RuleFor(x => x.RestaurantID)
            .NotEmpty().WithMessage("RestaurantID is required.")
            .GreaterThan(0).WithMessage("RestaurantID must be greater than zero.");
     
    }
}