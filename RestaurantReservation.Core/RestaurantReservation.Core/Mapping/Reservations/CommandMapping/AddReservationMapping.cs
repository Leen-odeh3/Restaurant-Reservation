using RestaurantReservation.Domain.Entities;
using AutoMapper;
using RestaurantReservation.Core.Features.Reservations.Commands.Models;

namespace RestaurantReservation.Core.Mapping.Orders;
public partial class ReservationProfile : Profile
{
    public void AddReservationMapping()
    {
        CreateMap<AddReservationCommand, Reservation>()
          .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID));
    }
}
