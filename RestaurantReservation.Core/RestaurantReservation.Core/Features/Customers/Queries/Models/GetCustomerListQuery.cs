
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Customers.Queries.Resultes;

namespace RestaurantReservation.Core.Features.Customers.Queries.Models;

public class GetCustomerListQuery : IRequest<Response<List<GetCustomerListResponse>>>
{
}
