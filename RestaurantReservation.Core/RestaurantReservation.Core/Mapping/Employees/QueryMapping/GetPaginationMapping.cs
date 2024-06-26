using AutoMapper;
using RestaurantReservation.Core.Features.Emoloyees.Queries.Resultsl;
using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Core.Mapping.Employees;
public partial class EmployeeProfile : Profile
{
    public void GetEmployeePaginationMapping()
    {

        CreateMap<Employee, GetEmployeePaginatedListResponse>()
            .ForMember(dest => dest.EmployeeID, opt => opt.MapFrom(src => src.EmployeeID))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src =>src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.ToString()))
            .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.Name));
    }
}
