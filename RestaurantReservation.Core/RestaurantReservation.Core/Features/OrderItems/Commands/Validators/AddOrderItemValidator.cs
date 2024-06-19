using FluentValidation;
using RestaurantReservation.Core.Features.OrderItems.Commands.Models;
namespace RestaurantReservation.Core.Features.OrderItems.Commands.Validators;
public class AddOrderItemValidator : AbstractValidator<AddOrderItemCommand>
{
    public AddOrderItemValidator()
    {
        RuleFor(x => x.RestaurantID).NotEmpty().WithMessage("Restaurant ID is required.");
    }
}
