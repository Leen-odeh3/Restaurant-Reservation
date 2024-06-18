﻿using MediatR;
using RestaurantReservation.Core.Bases;

namespace RestaurantReservation.Core.Features.OrderItems.Commands.Models;
public class DeleteReservationCommand : IRequest<Response<string>>
{
    public int ReservationID { get; set; }  

    public DeleteReservationCommand(int reservationId)
    {
        ReservationID = reservationId;
    }
}