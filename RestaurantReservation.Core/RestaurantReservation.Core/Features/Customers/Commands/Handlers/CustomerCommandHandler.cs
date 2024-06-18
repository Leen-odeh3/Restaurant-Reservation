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
        _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Response<Customer>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var mapper = _mapper.Map<Customer>(request);

        var result = await _customerService.AddAsync(mapper);

        if (result != null)
            return Created(result);
        return BadRequest<Customer>(result);
    }

    public async Task<Response<Customer>> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
    {
        var mapper = _mapper.Map<Customer>(request);

        var result = await _customerService.EditAsync(mapper);

        if (result != null)
            return Success(result);
        return BadRequest<Customer>(result);
    }

    public async Task<Response<string>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerService.GetByIdAsync(request.Id);

        if (customer == null)
            return NotFound<string>($"No customer found with Id: {request.Id}");

        var deletionResult = await _customerService.DeleteAsync(customer);

        if (deletionResult == "Success")
            return Deleted<string>();
        return BadRequest<string>("Failed to delete customer");
    }
}
