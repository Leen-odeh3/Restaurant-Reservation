namespace RestaurantReservation.Core.Features.Emoloyees.Queries.Results;

public class GetEmployeeListResponse
{
    public int EmployeeID { get; set; }
    public string FullName { get; set; } 
    public string Position { get; set; }
    public string RestaurantName { get; set; }
}
