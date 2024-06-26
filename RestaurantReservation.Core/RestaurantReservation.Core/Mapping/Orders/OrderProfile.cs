using AutoMapper;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.Orders;
public partial class OrderProfile : Profile
{
        public OrderProfile()
        {
            AddOrderMapping();
            EditOrderMapping();
            GetOrderListMapping();
            CreateMap<Order, Order>()
           .ForMember(dest => dest.OrderItems, opt => opt.Ignore());
    }
}