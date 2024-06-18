namespace RestaurantReservation.Core.Features.OrderItems.Queries.Results;
public class GetOrderItemListResponse
{
    public int OrderItemID { get; set; }
    public int OrderID { get; set; }
    public int MenuItemID { get; set; }
    public int Quantity { get; set; }

}
