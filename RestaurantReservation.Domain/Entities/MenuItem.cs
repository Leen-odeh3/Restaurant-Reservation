namespace RestaurantReservation.Domain.Entities;
public class MenuItem
{
    public int MenuItemID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int RestaurantID { get; set; }
    public virtual Restaurant Restaurant { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
