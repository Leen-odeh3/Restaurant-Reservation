using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Features.Reservations.Commands.Models;
public class AddReservationCommand : IRequest<Response<Reservation>>
{
    public int CustomerID { get; set; }
    public int RestaurantID { get; set; }
    public int? TableID { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
}
