using FluentValidation;
using RestaurantReservation.Core.Features.OrderItems.Commands.Models;
using RestaurantReservation.Services.Abstracts;


namespace RestaurantReservation.Core.Features.OrderItems.Commands.Validators;

public class EditReservationValidator : AbstractValidator<EditReservationCommand>
{
    private readonly IReservationService _reservationService;

    public EditReservationValidator(IReservationService reservationService)
    {
        _reservationService = reservationService;

        RuleFor(x => x.ReservationID)
            .NotEmpty().WithMessage("ReservationID is required.")
            .GreaterThan(0).WithMessage("Invalid ReservationID.");

        RuleFor(x => x.CustomerID)
            .NotEmpty().WithMessage("CustomerID is required.")
            .GreaterThan(0).WithMessage("Invalid CustomerID.");

        RuleFor(x => x.RestaurantID)
            .NotEmpty().WithMessage("RestaurantID is required.")
            .GreaterThan(0).WithMessage("Invalid RestaurantID.");

        RuleFor(x => x.PartySize)
            .NotEmpty().WithMessage("PartySize is required.")
            .GreaterThan(0).WithMessage("Invalid PartySize.");

        RuleFor(x => x.ReservationDate)
            .NotEmpty().WithMessage("ReservationDate is required.")
            .MustAsync(async (command, date, cancellationToken) =>
            {
                var existingReservation = await _reservationService.GetByIdAsync(command.ReservationID);
                return existingReservation != null && date > DateTime.Now;
            }).WithMessage("ReservationDate must be in the future.");
    }
}
