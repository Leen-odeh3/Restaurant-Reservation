using RestaurantReservation.Core.Features.Emoloyees.Commands.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.Employees;
public partial class EmployeeProfile 
{
    public void AddEmployeeMapping()
    {
        CreateMap<AddEmployeeCommand, Employee>()
           .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName));
    }
}
