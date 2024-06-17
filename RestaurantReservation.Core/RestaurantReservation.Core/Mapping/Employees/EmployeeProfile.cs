using AutoMapper;
using RestaurantReservation.Core.Features.Emoloyees.Queries.Results;
using RestaurantReservation.Domain.Entities;

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
