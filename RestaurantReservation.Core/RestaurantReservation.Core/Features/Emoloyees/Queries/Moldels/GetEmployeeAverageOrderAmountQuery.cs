using MediatR;
namespace RestaurantReservation.Core.Features.Emoloyees.Queries.Moldels;
public class GetEmployeeAverageOrderAmountQuery : IRequest<decimal>
{
    public int EmployeeId { get; }

    public GetEmployeeAverageOrderAmountQuery(int employeeId)
    {
        EmployeeId = employeeId;
    }
}
