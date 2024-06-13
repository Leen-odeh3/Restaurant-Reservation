namespace RestaurantReservation.Domain.Entities;
public class Table
{
    public int TableID { get; set; }
    public int Capacity { get; set; }
    public int RestaurantID { get; set; }
    public Restaurant Restaurant { get; set; }
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
