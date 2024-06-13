namespace RestaurantReservation.Domain.Entities;
public class MenuItem
{
    public int MenuItemID { get; set; }
    public int RestaurantID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}
