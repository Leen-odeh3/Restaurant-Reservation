namespace RestaurantReservation.Domain.Entities;
public class OrderItem
{
    public int OrderItemID { get; set; }
    public int Quantity { get; set; }
    public int? OrderID { get; set; }
    public int? MenuItemID { get; set; }
    public Order Order { get; set; }
    public MenuItem MenuItem { get; set; }
}
