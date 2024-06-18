namespace RestaurantReservation.Core.Features.OrderItems.Queries.Results;

public class GetReservationListResponse
{
    public int ReservationID { get; set; }
    public int CustomerID { get; set; }
    public string CustomerName { get; set; } 
    public int RestaurantID { get; set; }
    public string RestaurantName { get; set; } 
    public int? TableID { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
    public decimal TotalAmount { get; set; } 
}
