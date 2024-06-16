using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Restaurants.Queries.Results;
using RestaurantReservation.Core.Features.Tables.Queries.Results;

namespace RestaurantReservation.Core.Features.Tables.Queries.Models;
public class GetTableListQuery : IRequest<Response<List<GetTableListResponse>>>
{
}

