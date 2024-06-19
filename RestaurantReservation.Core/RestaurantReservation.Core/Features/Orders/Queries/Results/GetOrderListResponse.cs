namespace RestaurantReservation.Core.Features.Orders.Queries.Results
{
    public class GetOrderListResponse
    {
        public int OrderID { get; set; }
        public int ReservationID { get; set; }
        public String EmployeeName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
      
    }
}
