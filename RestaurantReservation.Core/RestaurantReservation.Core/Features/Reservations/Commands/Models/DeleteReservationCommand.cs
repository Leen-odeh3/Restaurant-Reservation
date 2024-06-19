using MediatR;
using RestaurantReservation.Core.Bases;

namespace RestaurantReservation.Core.FeaturesReservations.Commands.Models;
public class DeleteReservationCommand : IRequest<Response<string>>
{
    public int ReservationID { get; set; }  

    public DeleteReservationCommand(int reservationId)
    {
        ReservationID = reservationId;
    }
}
