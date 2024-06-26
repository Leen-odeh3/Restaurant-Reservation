using RestaurantReservation.Core.Features.Customers.Queries.Resultes;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.Customers;

public partial class CustomerProfile
{
    public void GetCustomerListMapping()
    {
        CreateMap<Customer, GetCustomerListResponse>()
            .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.CustomerPhoneNumber, opt => opt.MapFrom(src => src.CustomerPhoneNumber))
            .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Reservations.FirstOrDefault().restaurant.Name))
            .ForMember(dest => dest.TableID, opt => opt.MapFrom(src => src.Reservations.FirstOrDefault().TableID))
            .ForMember(dest => dest.ReservationDate, opt => opt.MapFrom(src => src.Reservations.FirstOrDefault().ReservationDate));
    }
}
