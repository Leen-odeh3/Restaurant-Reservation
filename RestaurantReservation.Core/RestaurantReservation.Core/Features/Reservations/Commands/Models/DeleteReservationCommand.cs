using MediatR;
using RestaurantReservation.Core.Bases;

namespace RestaurantReservation.Core.Features.OrderItems.Commands.Models;
public class DeleteOrderItemCommand : IRequest<Response<string>>
{
    public int ReservationID { get; set; }  

    public DeleteOrderItemCommand(int reservationId)
    {
        ReservationID = reservationId;
    }
}
