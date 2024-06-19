using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Domain.Entities;
using System;
using System.Collections.Generic;
namespace RestaurantReservation.Core.Features.Orders.Commands.Models;
public class AddOrderCommand : IRequest<Response<Order>>
{
    public int ReservationID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
}