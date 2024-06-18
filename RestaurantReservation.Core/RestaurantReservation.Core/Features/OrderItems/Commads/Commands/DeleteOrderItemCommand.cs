
using MediatR;
using RestaurantReservation.Core.Bases;

namespace RestaurantReservation.Core.Features.OrderItems.Commads.Commands;
public class DeleteOrderItemCommand : IRequest<Response<string>>
{
    public int OrderItemID { get; set; }
    public DeleteOrderItemCommand(int orderItemId)
    {
        OrderItemID = orderItemId;
    }
}
