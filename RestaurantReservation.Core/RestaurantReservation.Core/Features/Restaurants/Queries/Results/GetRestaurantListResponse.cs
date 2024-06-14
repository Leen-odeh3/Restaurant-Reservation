namespace RestaurantReservation.Core.Features.Restaurants.Queries.Results;
public class GetRestaurantListResponse
{
    public int RestaurantID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string OperatingHours { get; set; }
}
