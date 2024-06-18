using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.OrderItems.Queries.Results;

namespace RestaurantReservation.Core.Features.OrderItems.Queries.Models;
public class GetOrderItemListQuery : IRequest<Response<List<GetOrderItemListResponse>>>
{
}
