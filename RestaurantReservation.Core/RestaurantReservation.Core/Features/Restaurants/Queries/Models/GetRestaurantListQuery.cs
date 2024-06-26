using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Restaurants.Queries.Results;

namespace RestaurantReservation.Core.Features.Restaurants.Queries.Models;
public class GetRestaurantListQuery : IRequest<Response<List<GetRestaurantListResponse>>>
{
}
