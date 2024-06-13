using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Domain.Entities;
public class Order
{
    public int OrderID { get; set; }
    public int ReservationID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal TotalAmount { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}