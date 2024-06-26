using MediatR;
using RestaurantReservation.Core.Features.Reservations.Queries.Results;
namespace RestaurantReservation.Core.Features.Reservations.Queries.Models;
public class GetReservationListQuery : IRequest<List<GetReservationListResponse>>
{
}
