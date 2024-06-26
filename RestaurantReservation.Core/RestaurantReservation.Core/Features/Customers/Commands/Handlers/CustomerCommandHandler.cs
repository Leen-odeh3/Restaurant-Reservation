using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Customers.Commands.Models;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.Customers.Commands.Handlers;

public class CustomerCommandHandler : ResponseHandler,
                                       IRequestHandler<AddCustomerCommand, Response<Customer>>,
                                       IRequestHandler<EditCustomerCommand, Response<Customer>>,
                                       IRequestHandler<DeleteCustomerCommand, Response<string>>
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerCommandHandler(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    public async Task<Response<Customer>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var mappedCustomer = _mapper.Map<Customer>(request);

        var result = await _customerService.AddAsync(mappedCustomer);

        return result is not null ? Success(result) : Fail<Customer>("Failed to add customer");

    }

    public async Task<Response<Customer>> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
    {
        var mapper = _mapper.Map<Customer>(request);

        var result = await _customerService.EditAsync(mapper);

        return result is not null ? Success(result) : Fail<Customer>("Failed to edit customer");

    }

    public async Task<Response<string>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerService.GetByIdAsync(request.Id);
        if (customer is null)
            return NotFound<string>($"No customer found with Id: {request.Id}");

        var deletionResult = await _customerService.DeleteAsync(customer);
        return deletionResult == "Success" ? Deleted<string>() : Fail<string>("Failed to delete customer");
    }
}
