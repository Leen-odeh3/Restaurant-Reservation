namespace RestaurantReservation.Core.Features.Reservations.Queries.Results;

public class GetReservationListResponse
{
    public int ReservationID { get; set; }
    public string CustomerName { get; set; } 
    public string RestaurantName { get; set; } 
    public int? TableID { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
}
