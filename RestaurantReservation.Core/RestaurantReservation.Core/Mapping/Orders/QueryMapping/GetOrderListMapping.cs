using AutoMapper;
using RestaurantReservation.Core.Features.Orders.Queries.Results;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Core.Mapping.Orders;
public partial class OrderProfile : Profile
{
        public void GetOrderListMapping()
        {
            CreateMap<Order, GetOrderListResponse>()
                .ForMember(dest => dest.OrderID, opt => opt.MapFrom(src => src.OrderID));
        }
}
