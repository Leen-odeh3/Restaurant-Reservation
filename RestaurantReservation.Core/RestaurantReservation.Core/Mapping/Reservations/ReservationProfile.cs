using AutoMapper;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.Orders;
public partial class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        AddReservationMapping();
        EditReservationMapping();
        GetReservationListMapping();
        CreateMap<Reservation, Reservation>();

    }

}
