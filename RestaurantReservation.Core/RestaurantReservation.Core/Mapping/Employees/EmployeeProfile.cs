using AutoMapper;
namespace RestaurantReservation.Core.Mapping.Employees;

public partial class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        AddEmployeeMapping();
        EditEmployeeMapping();
        GetEmployeeMapping();
    }
}
