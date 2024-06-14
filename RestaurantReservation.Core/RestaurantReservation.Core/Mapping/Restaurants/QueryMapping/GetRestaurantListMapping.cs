using RestaurantReservation.Core.Features.Restaurants.Queries.Results;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.Restaurants;
public partial class StudentProfile
{
    public void GetRestaurantListMapping()
    {
        CreateMap<Restaurant, GetRestaurantListResponse>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RestaurantID));          
    }

}
