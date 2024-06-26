using RestaurantReservation.Core.Features.Emoloyees.Queries.Results;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Core.Mapping.Employees;
public partial class EmployeeProfile
{
    public void GetEmployeeMapping()
    {
        CreateMap<Employee, GetEmployeeListResponse>()
      .ForMember(dest => dest.EmployeeID, opt => opt.MapFrom(src => src.EmployeeID))
      .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
      .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.ToString()))
      .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.Name));

    }
}
