using RestaurantReservation.Core.Features.Customers.Queries.Resultes;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.Customers;
public partial class CustomerProfile
{
    public void GetCustomerListMapping()
    {
        CreateMap<Customer, GetCustomerListResponse>()
            .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.CustomerPhoneNumber, opt => opt.MapFrom(src => src.CustomerPhoneNumber));
    }
}
