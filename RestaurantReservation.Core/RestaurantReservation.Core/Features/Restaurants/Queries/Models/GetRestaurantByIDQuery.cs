using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Restaurants.Queries.Results;

namespace RestaurantReservation.Core.Features.Restaurants.Queries.Models;
public class GetRestaurantByIDQuery : IRequest<Response<GetRestaurantListResponse>>
{
    public int Id { get; set; }
    public GetRestaurantByIDQuery(int id)
    {
        Id = id;
    }
}
