using AutoMapper;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.Restaurants;
public partial class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
       GetRestaurantListMapping();
       GetRestaurantByIDMapping();
       AddRestaurantMapping();
       EditRestaurantMapping();
       CreateMap<Restaurant, Restaurant>();

    }

}
