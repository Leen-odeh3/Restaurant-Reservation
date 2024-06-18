﻿using RestaurantReservation.Domain.Entities;
using AutoMapper;
using RestaurantReservation.Core.Features.OrderItems.Commands.Models;
using RestaurantReservation.Core.Features.OrderItems.Commands;

namespace RestaurantReservation.Core.Mapping.Orders;
public partial class ReservationProfile : Profile
{
    public void AddReservationMapping()
    {
        CreateMap<AddOrderItemCommand, Reservation>();
    }
}
