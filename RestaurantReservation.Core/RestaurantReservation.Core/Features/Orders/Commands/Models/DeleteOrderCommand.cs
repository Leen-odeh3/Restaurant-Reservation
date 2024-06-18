using MediatR;
using RestaurantReservation.Core.Bases;

namespace RestaurantReservation.Core.Features.Orders.Commands.Models;
public class DeleteOrderCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeleteOrderCommand(int id)
    {
        Id = id;
    }
}