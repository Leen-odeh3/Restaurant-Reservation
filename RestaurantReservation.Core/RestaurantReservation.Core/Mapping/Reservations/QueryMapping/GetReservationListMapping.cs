using AutoMapper;
using RestaurantReservation.Core.Features.Reservations.Queries.Results;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Core.Mapping.Orders;
public partial class ReservationProfile : Profile
{
        public void GetReservationListMapping()
        {
            CreateMap<Reservation, GetReservationListResponse>()
                .ForMember(dest => dest.ReservationID, opt => opt.MapFrom(src => src.ReservationID))
                 .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.restaurant.Name))
                 .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.customer.FirstName));
        }
}
