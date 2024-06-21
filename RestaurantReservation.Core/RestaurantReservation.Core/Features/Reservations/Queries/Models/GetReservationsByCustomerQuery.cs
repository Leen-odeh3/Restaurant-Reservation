using MediatR;
using RestaurantReservation.Core.Features.Reservations.Queries.Results;
namespace RestaurantReservation.Core.Features.Reservations.Queries.Models;
public class GetReservationsByCustomerQuery : IRequest<List<GetReservationListResponse>>
{
    public int CustomerId { get; set; }

    public GetReservationsByCustomerQuery(int customerId)
    {
        CustomerId = customerId;
    }
}
