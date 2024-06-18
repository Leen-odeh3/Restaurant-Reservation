using AutoMapper;
using RestaurantReservation.Core.Features.OrderItems.Queries.Results;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Core.Mapping.Orders;
public partial class ReservationProfile : Profile
{
        public void GetReservationListMapping()
        {
            CreateMap<Reservation, GetReservationListResponse>()
                .ForMember(dest => dest.ReservationID, opt => opt.MapFrom(src => src.ReservationID));
        }
}
