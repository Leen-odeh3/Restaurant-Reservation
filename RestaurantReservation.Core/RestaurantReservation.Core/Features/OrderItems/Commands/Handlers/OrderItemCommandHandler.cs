using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.OrderItems.Commands.Models;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.OrderItems.Commands.Handlers;
public class OrderItemCommandHandler : ResponseHandler,
        IRequestHandler<AddOrderItemCommand, Response<OrderItem>>,
        IRequestHandler<UpdateOrderItemCommand, Response<OrderItem>>,
        IRequestHandler<DeleteOrderItemCommand, Response<string>>
{
    private readonly IOrderItemService _orderItemService;
    private readonly IMapper _mapper;

    public OrderItemCommandHandler(IOrderItemService orderItemService, IMapper mapper)
    {
        _orderItemService = orderItemService ?? throw new ArgumentNullException(nameof(orderItemService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Response<OrderItem>> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        var orderItem = _mapper.Map<OrderItem>(request);

        try
        {
            var result = await _orderItemService.AddAsync(orderItem);
            return Success(result);
        }
        catch (Exception ex)
        {
            return Fail<OrderItem>($"Failed to add OrderItem: {ex.Message}");
        }
    }

    public async Task<Response<OrderItem>> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
    {
        var orderItem = _mapper.Map<OrderItem>(request);

        try
        {
            var result = await _orderItemService.EditAsync(orderItem);
            return Success(result);
        }
        catch (Exception ex)
        {
            return Fail<OrderItem>($"Failed to update OrderItem: {ex.Message}");
        }
    }

    public async Task<Response<string>> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
    {
        var orderItem = await _orderItemService.GetByIdAsync(request.OrderItemID);

        if (orderItem == null)
            return NotFound<string>($"No OrderItem found with Id: {request.OrderItemID}");

        try
        {
            var deletionResult = await _orderItemService.DeleteAsync(orderItem);
            return Success("OrderItem deleted successfully");
        }
        catch (Exception ex)
        {
            return Fail<string>($"Failed to delete OrderItem: {ex.Message}");
        }
    }
}