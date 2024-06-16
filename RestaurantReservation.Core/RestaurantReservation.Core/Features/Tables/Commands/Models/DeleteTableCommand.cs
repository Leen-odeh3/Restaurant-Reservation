using MediatR;
using RestaurantReservation.Core.Bases;

namespace RestaurantReservation.Core.Features.Tables.Commands.Models;
public class DeleteTableCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public DeleteTableCommand(int id)
    {
        Id = id;
    }
}