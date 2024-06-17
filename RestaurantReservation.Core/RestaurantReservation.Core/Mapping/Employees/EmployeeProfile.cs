using AutoMapper;
using RestaurantReservation.Core.Features.Emoloyees.Queries.Results;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.Employees;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, GetEmployeeListResponse>()
            .ForMember(dest => dest.EmployeeID, opt => opt.MapFrom(src => src.EmployeeID))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.ToString()))
            .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.Name));
    }
}
