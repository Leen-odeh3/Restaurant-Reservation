using AutoMapper;
namespace RestaurantReservation.Core.Mapping.Customers;
public partial class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        AddCommandMapping();
        EditCommandMapping();
        GetCustomerListMapping();
    }
  }
