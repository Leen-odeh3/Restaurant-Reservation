using MediatR;
using RestaurantReservation.Core.Features.Restaurants.Queries.Results;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Features.Restaurants.Queries.Models;
public class GetRestaurantListQuery : IRequest<List<Restaurant>>
{
}
