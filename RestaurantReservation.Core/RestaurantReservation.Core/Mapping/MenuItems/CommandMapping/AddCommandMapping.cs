using RestaurantReservation.Core.Features.MenuItems.Commands.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.MenuItems;
public partial class MenuItemProfile 
{
    public void AddMenuItemMapping()
    {
        CreateMap<AddMenuItemCommand, MenuItem>()
           .ForMember(dest => dest.MenuItemID, opt => opt.MapFrom(src => src.MenuItemID));
    }
}
