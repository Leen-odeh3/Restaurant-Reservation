using AutoMapper;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Core.Mapping.Customers;
public partial class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        AddCommandMapping();
        EditCommandMapping();
        GetCustomerListMapping();
        CreateMap<Customer, Customer>();

    }
}
