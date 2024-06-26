using AutoMapper;
using RestaurantReservation.Core.Features.Restaurants.Commands.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.Restaurants;
public partial class RestaurantProfile : Profile
{
    public void EditRestaurantMapping()
    {
        CreateMap<EditRestaurantCommand, Restaurant>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RestaurantName)).
           ForMember(dest => dest.RestaurantID, opt => opt.MapFrom(src => src.Id));
    }
}
