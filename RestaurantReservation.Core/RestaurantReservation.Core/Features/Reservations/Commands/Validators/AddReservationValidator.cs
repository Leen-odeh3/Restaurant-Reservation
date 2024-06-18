using FluentValidation;
using RestaurantReservation.Core.Features.OrderItems.Commands.Models;

namespace RestaurantReservation.Core.Features.OrderItems.Commands.Validators;

public class AddReservationValidator : AbstractValidator<AddReservationCommand>
{
    public AddReservationValidator()
    {
        RuleFor(x => x.CustomerID)
            .NotEmpty().WithMessage("CustomerID is required.")
            .GreaterThan(0).WithMessage("CustomerID must be greater than zero.");

        RuleFor(x => x.RestaurantID)
            .NotEmpty().WithMessage("RestaurantID is required.")
            .GreaterThan(0).WithMessage("RestaurantID must be greater than zero.");

        RuleFor(x => x.ReservationDate)
            .NotEmpty().WithMessage("ReservationDate is required.")
            .Must(date => date > DateTime.Now).WithMessage("ReservationDate must be in the future.");

        RuleFor(x => x.PartySize)
            .NotEmpty().WithMessage("PartySize is required.")
            .GreaterThan(0).WithMessage("PartySize must be greater than zero.");
    }
}