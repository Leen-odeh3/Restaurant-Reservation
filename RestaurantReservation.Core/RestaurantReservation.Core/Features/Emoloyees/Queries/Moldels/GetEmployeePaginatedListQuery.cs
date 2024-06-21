using MediatR;
using RestaurantReservation.Core.Features.Emoloyees.Queries.Resultsl;
using RestaurantReservation.Core.Wrappers;
using RestaurantReservation.Domain.Enums;

namespace RestaurantReservation.Core.Features.Emoloyees.Queries.Moldels;
public class GetEmployeePaginatedListQuery : IRequest<PaginatedResult<GetEmployeePaginatedListResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public EmployeePosition OrderBy { get; set; }
    public string? Search { get; set; }
}
