using MediatR;
using RestaurantReservation.Core.Bases;

namespace RestaurantReservation.Core.Features.MenuItems.Commands.Models;

public class DeleteMenuItemCommand : IRequest<Response<string>>
{  
    public int Id { get; set; }
    public DeleteMenuItemCommand(int id)
    {
       Id = id;
    }
}
