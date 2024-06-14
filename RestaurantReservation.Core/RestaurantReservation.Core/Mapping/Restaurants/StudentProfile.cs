using AutoMapper;

namespace RestaurantReservation.Core.Mapping.Restaurants;
public partial class StudentProfile : Profile
{
    public StudentProfile()
    {
       GetRestaurantListMapping();
        GetRestaurantByIDMapping();
    }
 
}
