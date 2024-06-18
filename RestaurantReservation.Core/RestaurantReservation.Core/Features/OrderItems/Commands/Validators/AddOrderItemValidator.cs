using FluentValidation;
using RestaurantReservation.Core.Features.OrderItems.Commands.Models;
namespace RestaurantReservation.Core.Features.OrderItems.Commands.Validators;
public class AddOrderItemValidator : AbstractValidator<AddOrderItemCommand>
{
    public AddOrderItemValidator()
    {
        RuleFor(x => x.CustomerID).NotEmpty().WithMessage("Customer ID is required.");
        RuleFor(x => x.RestaurantID).NotEmpty().WithMessage("Restaurant ID is required.");
        RuleFor(x => x.ReservationDate).NotEmpty().WithMessage("Reservation date is required.")
                                         .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Reservation date must be today or later.");
        RuleFor(x => x.PartySize).GreaterThan(0).WithMessage("Party size must be greater than zero.");
    }
}
