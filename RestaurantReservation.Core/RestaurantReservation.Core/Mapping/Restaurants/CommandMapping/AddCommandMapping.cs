using AutoMapper;
using RestaurantReservation.Core.Features.Restaurants.Commands.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.Restaurants;
public partial class RestaurantProfile
{
    public void AddRestaurantMapping()
    {
        CreateMap<AddRestaurantCommand,Restaurant>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RestaurantName));
    }
}
