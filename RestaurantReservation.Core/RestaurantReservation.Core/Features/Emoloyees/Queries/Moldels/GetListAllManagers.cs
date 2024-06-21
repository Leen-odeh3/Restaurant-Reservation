using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Emoloyees.Queries.Results;

namespace RestaurantReservation.Core.Features.Emoloyees.Queries.Moldels;
public class GetListAllManagers : IRequest<Response<List<GetEmployeeListResponse>>>
{
}
