using MediatR;
using RestaurantReservation.Core.Bases;
namespace RestaurantReservation.Core.Features.MenuItems.Commands.Models;
public class EditMenuItemCommand : IRequest<Response<Domain.Entities.MenuItem>>
{
    public int MenuItemID { get; set; }
    public int RestaurantID  { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}
