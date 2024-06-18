using RestaurantReservation.Core.Features.Orders.Commands.Models;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Core.Mapping.Orders;
public partial class OrderProfile
{
    public void EditOrderMapping()
    {
        CreateMap<EditOrderCommand, Order>()
            .ForMember(dest => dest.OrderID, opt => opt.MapFrom(src => src.Id));
    }
}
