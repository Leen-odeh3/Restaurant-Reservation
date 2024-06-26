using RestaurantReservation.Domain.Enums;

namespace RestaurantReservation.Core.Features.Emoloyees.Queries.Resultsl;
public class GetEmployeePaginatedListResponse
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public string RestaurantName { get; set; }
    public GetEmployeePaginatedListResponse()
    {
        
    }
    public GetEmployeePaginatedListResponse(int employeeID, string first, String last, string position, string restaurantName)
    {
        EmployeeID = employeeID;
        FirstName = first;
        LastName = last;
        Position = position;
        RestaurantName = restaurantName;
    }
}
