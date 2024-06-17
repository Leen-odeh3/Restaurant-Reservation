using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Domain.Enums;

namespace RestaurantReservation.Core.Features.Emoloyees.Commands.Models;

public class AddEmployeeCommand : IRequest<Response<Employee>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmployeePosition Position { get; set; }
    public int RestaurantID { get; set; }
}
