using FluentValidation;
using RestaurantReservation.Core.Features.Customers.Commands.Models;
using RestaurantReservation.Services.Abstracts;
namespace RestaurantReservation.Core.Features.Customers.Commands.Validators;
public class AddCustomerValidator : AbstractValidator<AddCustomerCommand>
{
    private readonly ICustomerService _customerService;
    public AddCustomerValidator(ICustomerService customerService)
    {
        _customerService = customerService;
        ApplyValidationRules();
        //ApplyCustomValidationsRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.CustomerPhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .MaximumLength(18).WithMessage("Phone number cannot exceed 18 characters.");
    }

    /*public void ApplyCustomValidationsRules()
    {
        RuleFor(x => x.Email)
            .MustAsync(async (Key, CancellationToken) => !await _customerService.IsEmailExist(Key))
            .WithMessage("");
        RuleFor(x => x.CustomerPhoneNumber)
           .MustAsync(async (Key, CancellationToken) => !await _customerService.IsCustomerPhoneExist(Key))
           .WithMessage("");
    }*/

}