namespace RestaurantReservation.Domain.Entities;
public class Order
{
    public int OrderID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public int EmployeeID { get; set; }
    public int ReservationID { get; set; }
    public Employee Employee { get; set; }
    public Reservation Reservation { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
