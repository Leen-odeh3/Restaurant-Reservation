using RestaurantReservation.Core.Features.Emoloyees.Commands.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Mapping.Employees;
public partial class EmployeeProfile 
{
    public void EditEmployeeMapping()
    {
        CreateMap<EditEmployeeCommand, Employee>()
           .ForMember(dest => dest.EmployeeID, opt => opt.MapFrom(src => src.EmployeeID));
    }

}
