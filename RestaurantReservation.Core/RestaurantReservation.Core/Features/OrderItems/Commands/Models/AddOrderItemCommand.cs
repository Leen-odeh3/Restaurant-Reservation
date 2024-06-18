using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Features.OrderItems.Commands;
public class AddOrderItemCommand : IRequest<Response<OrderItem>>
{
    public int OrderID { get; set; }
    public int MenuItemID { get; set; }
    public int Quantity { get; set; }
    public int CustomerID { get; set; }
    public int RestaurantID { get; set; }
    public int? TableID { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }

}
