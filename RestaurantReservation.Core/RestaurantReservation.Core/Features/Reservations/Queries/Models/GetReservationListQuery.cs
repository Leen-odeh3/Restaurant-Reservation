using MediatR;
using RestaurantReservation.Core.Features.OrderItems.Queries.Results;

namespace RestaurantReservation.Core.Features.OrderItems.Queries.Models;
public class GetReservationListQuery : IRequest<List<GetReservationListResponse>>
{
}
