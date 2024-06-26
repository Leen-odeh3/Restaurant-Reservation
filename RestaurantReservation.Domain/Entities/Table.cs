namespace RestaurantReservation.Domain.Entities;
public class Table
{
    public int TableID { get; set; }
    public int RestaurantID { get; set; }
    public int Capacity { get; set; }
    public Restaurant Restaurant { get; set; }
    public List<Reservation> Reservations { get; set; }
}