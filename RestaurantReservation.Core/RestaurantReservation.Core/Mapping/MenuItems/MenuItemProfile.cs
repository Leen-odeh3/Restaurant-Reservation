using AutoMapper;
namespace RestaurantReservation.Core.Mapping.MenuItems;
public partial class MenuItemProfile : Profile
{
    public MenuItemProfile()
    {
        GetMenueItemListMapping();
        AddMenuItemMapping();
        EditMenuItemMapping();
    }
    
}
