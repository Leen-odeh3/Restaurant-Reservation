using AutoMapper;
using RestaurantReservation.Core.Features.MenuItems.Queries.Results;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Core.Mapping.MenuItems;
public partial class MenuItemProfile : Profile
{
    public void GetMenueItemListMapping()
    {
        CreateMap<MenuItem, GetMenuItemListResponse>()
           .ForMember(dest => dest.MenuItemID, opt => opt.MapFrom(src => src.RestaurantID))
            .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.Name));
    }
}
