namespace RestaurantReservation.Core.Features.Customers.Queries.Resultes;
public class GetCustomerListResponse
{
   public int CustomerID { get; set; }
   public string CustomerName { get; set; }
   public string Email { get; set; }
   public string CustomerPhoneNumber { get; set; }
   public String RestaurantName { get; set; }
   public int TableID { get; set; }
   public DateTime ReservationDate { get; set; }
}
