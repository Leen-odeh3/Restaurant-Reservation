using RestaurantReservation.Core.Features.OrderItems.Commands.Models;
using RestaurantReservation.Core.Features.Orders.Commands.Models;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Core.Mapping.Orders;
public partial class ReservationProfile
{
    public void EditReservationMapping()
    {
        CreateMap<EditReservationCommand, Reservation>()
            .ForMember(dest => dest.ReservationID, opt => opt.MapFrom(src => src.ReservationID));
    }
}
