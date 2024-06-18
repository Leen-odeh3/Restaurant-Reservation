using FluentValidation;
using RestaurantReservation.Core.Features.Orders.Commands.Models;
using RestaurantReservation.Services.Abstracts;
namespace RestaurantReservation.Core.Features.Orders.Commands.Validators;

public class EditOrderValidator : AbstractValidator<EditOrderCommand>
{
    private readonly IOrderService _orderService;

    public EditOrderValidator(IOrderService orderService)
    {
        _orderService = orderService;
        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.ReservationID).NotEmpty().WithMessage("Reservation ID is required.");
        RuleFor(x => x.EmployeeID).NotEmpty().WithMessage("Employee ID is required.");
        RuleFor(x => x.TotalAmount).GreaterThan(0).WithMessage("Total amount must be greater than 0.");
    }
}
