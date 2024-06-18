using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Features.OrderItems.Commands.Models;

public class DeleteOrderItemCommand : IRequest<Response<string>>
{
    public int OrderItemID { get; set; }
    public DeleteOrderItemCommand(int orderItemId)
    {
        OrderItemID = orderItemId;
    }
}
