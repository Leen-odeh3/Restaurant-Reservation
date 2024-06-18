using MediatR;
using RestaurantReservation.Core.Bases;
namespace RestaurantReservation.Core.Features.Customers.Commands.Models;
public class EditCustomerCommand : IRequest<Response<Domain.Entities.Customer>>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string CustomerPhoneNumber { get; set; }
}
