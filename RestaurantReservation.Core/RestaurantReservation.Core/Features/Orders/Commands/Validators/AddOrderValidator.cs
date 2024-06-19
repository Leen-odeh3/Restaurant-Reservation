using FluentValidation;
using RestaurantReservation.Core.Features.Orders.Commands.Models;

namespace RestaurantReservation.Core.Features.Orders.Commands.Validators;
public class AddOrderValidator : AbstractValidator<AddOrderCommand>
{
    public AddOrderValidator()
    {
        RuleFor(x => x.ReservationID).NotEmpty().WithMessage("Reservation ID is required.");
        RuleFor(x => x.EmployeeID).NotEmpty().WithMessage("Employee ID is required.");
    }
}
