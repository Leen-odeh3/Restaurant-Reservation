using MediatR;
using RestaurantReservation.Core.Bases;

namespace RestaurantReservation.Core.Features.Emoloyees.Commands.Models;
public class DeleteEmployeeCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeleteEmployeeCommand(int id)
    {
        Id = id;
    }
}
