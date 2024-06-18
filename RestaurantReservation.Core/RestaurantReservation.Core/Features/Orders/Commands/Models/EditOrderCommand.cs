using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Core.Features.Orders.Commands.Models;
public class EditOrderCommand : IRequest<Response<Order>>
{
    public int Id { get; set; }
    public int ReservationID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}
