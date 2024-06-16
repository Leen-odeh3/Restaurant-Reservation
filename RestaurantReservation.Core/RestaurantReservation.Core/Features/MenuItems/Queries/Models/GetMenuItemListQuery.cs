using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.MenuItems.Queries.Results;
namespace RestaurantReservation.Core.Features.MenuItems.Queries.Models;

public class GetMenuItemListQuery : IRequest<Response<List<GetMenuItemListResponse>>>
{
}
