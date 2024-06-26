using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Orders.Commands.Models;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Services.Abstracts;


namespace RestaurantReservation.Core.Features.Orders.Commands.Handlers;

public class OrderCommandHandler : ResponseHandler,
                                   IRequestHandler<AddOrderCommand, Response<Order>>,
                                   IRequestHandler<EditOrderCommand, Response<Order>>,
                                   IRequestHandler<DeleteOrderCommand, Response<string>>
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderCommandHandler(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    public async Task<Response<Order>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var mappedOrder = _mapper.Map<Order>(request);
        var result = await _orderService.AddAsync(mappedOrder);

        if (result is not null) return Created(result);
        return BadRequest<Order>(result);
    }

    public async Task<Response<Order>> Handle(EditOrderCommand request, CancellationToken cancellationToken)
    {
        var mappedOrder = _mapper.Map<Order>(request);
        var result = await _orderService.EditAsync(mappedOrder);

        if (result is not null) return Success(result);
        return BadRequest<Order>(result);
    }

    public async Task<Response<string>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderService.GetByIdAsync(request.Id);

        if (order is null)
        {
            return NotFound<string>("Order not found");
        }

        var deletionResult = await _orderService.DeleteAsync(order);

        if (deletionResult == "Success")
        {
            return Deleted<string>();
        }
        else
        {
            return BadRequest<string>("Failed to delete order");
        }
    }
}
