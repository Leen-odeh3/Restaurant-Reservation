using RestaurantReservation.Core.Features.MenuItems.Commands.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.MenuItems;
public partial class MenuItemProfile
{
    public void EditMenuItemMapping()
    {
        CreateMap<EditMenuItemCommand, MenuItem>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}

