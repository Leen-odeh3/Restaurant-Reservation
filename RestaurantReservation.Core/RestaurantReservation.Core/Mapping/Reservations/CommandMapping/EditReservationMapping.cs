﻿using RestaurantReservation.Core.FeaturesReservations.Commands.Models;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Core.Mapping.Orders;
public partial class ReservationProfile
{
    public void EditReservationMapping()
    {
        CreateMap<EditReservationCommand, Reservation>()
            .ForMember(dest => dest.ReservationID, opt => opt.MapFrom(src => src.ReservationID));
    }
}
