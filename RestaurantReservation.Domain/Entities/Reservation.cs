namespace RestaurantReservation.Domain.Entities;
public class Reservation
{
    public int ReservationID { get; set; }
    public int CustomerID { get; set; }
    public int RestaurantID { get; set; }
    public int? TableID { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
    public List<Order> Orders { get; set; }

    // Navigation property to Table
    public Table Table { get; set; }
}