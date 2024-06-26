using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Domain.Entities;
public class OrderItem
{
    public int OrderItemID { get; set; } 
    [ForeignKey("OrderID")]
    public int OrderID { get; set; }
    [ForeignKey("MenuItemID")]
    public int MenuItemID { get; set; }
    public int Quantity { get; set; }
    public Order Order { get; set; }  
    public MenuItem Item { get; set; }
}
