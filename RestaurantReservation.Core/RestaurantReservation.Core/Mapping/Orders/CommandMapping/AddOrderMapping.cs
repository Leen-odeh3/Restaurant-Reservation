using RestaurantReservation.Core.Features.Orders.Commands.Models;
using RestaurantReservation.Domain.Entities;
using AutoMapper;

namespace RestaurantReservation.Core.Mapping.Orders;
public partial class OrderProfile : Profile
{
    public void AddOrderMapping()
    {
        CreateMap<AddOrderCommand, Order>();
    }
}
