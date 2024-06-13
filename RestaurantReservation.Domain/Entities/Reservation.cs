namespace RestaurantReservation.Domain.Entities;
public class Reservation
{
    public int ReservationID { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
    public int CustomerID { get; set; }
    public int RestaurantID { get; set; }
    public int TableID { get; set; }
    public Customer Customer { get; set; }
    public Restaurant Restaurant { get; set; }
    public Table Table { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}
