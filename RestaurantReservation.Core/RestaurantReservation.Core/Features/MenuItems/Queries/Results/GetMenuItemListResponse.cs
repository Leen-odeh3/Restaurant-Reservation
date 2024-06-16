namespace RestaurantReservation.Core.Features.MenuItems.Queries.Results;

public class GetMenuItemListResponse
{
    public int MenuItemID { get; set; }
    public String RestaurantName { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}
