using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Orders.Queries.Results;

namespace RestaurantReservation.Core.Features.Orders.Queries.Models;

public class GetOrderListQuery : IRequest<Response<List<GetOrderListResponse>>>
{
}
