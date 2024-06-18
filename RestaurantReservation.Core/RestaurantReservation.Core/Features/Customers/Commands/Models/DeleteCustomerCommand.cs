using MediatR;
using RestaurantReservation.Core.Bases;
namespace RestaurantReservation.Core.Features.Customers.Commands.Models;

public class DeleteCustomerCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeleteCustomerCommand(int id)
    {
        Id = id;
    }
}
