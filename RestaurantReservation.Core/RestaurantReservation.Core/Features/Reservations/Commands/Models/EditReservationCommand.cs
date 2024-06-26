using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.FeaturesReservations.Commands.Models;
public class EditReservationCommand : IRequest<Response<Reservation>>
{
    public int ReservationID { get; set; } 
    public int CustomerID { get; set; }     
    public int RestaurantID { get; set; }  
    public int? TableID { get; set; }     
    public DateTime ReservationDate { get; set; } 
    public int PartySize { get; set; }   

    public EditReservationCommand(int reservationId)
    {
        ReservationID = reservationId;
    }
}