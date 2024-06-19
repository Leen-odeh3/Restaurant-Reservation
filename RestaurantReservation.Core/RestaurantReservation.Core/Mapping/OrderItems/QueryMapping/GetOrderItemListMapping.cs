using AutoMapper;
using RestaurantReservation.Core.Features.OrderItems.Queries.Results;
using RestaurantReservation.Core.Features.Reservations.Queries.Results;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.MenueItems;
public partial class OrderItemProfile : Profile
{
    public void GetOrderItemListMapping()
    {
        CreateMap<OrderItem, GetOrderItemListResponse>().
        ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Order.reservation.restaurant.Name));
} 
}
