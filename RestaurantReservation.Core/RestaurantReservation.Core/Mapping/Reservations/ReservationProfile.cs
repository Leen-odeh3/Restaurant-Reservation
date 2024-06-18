using AutoMapper;

namespace RestaurantReservation.Core.Mapping.Orders;
public partial class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        AddReservationMapping();
        EditReservationMapping();
        GetReservationListMapping();
    }

}
