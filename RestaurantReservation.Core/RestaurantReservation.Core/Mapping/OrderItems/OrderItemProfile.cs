using AutoMapper;
using RestaurantReservation.Core.Features.OrderItems.Commands;
using RestaurantReservation.Core.Features.OrderItems.Commands.Models;
using RestaurantReservation.Core.Features.OrderItems.Queries.Results;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.MenueItems;
public partial class OrderItemProfile :Profile
{
    public OrderItemProfile()
    {
        GetOrderItemListMapping();
        CreateMap<AddOrderItemCommand, OrderItem>();
        CreateMap<UpdateOrderItemCommand, OrderItem>();
    }
}
