using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Core.Features.OrderItems.Commads.Commands;
public class UpdateOrderItemCommand : IRequest<Response<OrderItem>>
{
    public int OrderItemID { get; set; }
    public int OrderID { get; set; }
    public int MenuItemID { get; set; }
    public int Quantity { get; set; }

}
