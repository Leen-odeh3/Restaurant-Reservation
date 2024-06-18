namespace RestaurantReservation.Core.Features.Customers.Queries.Resultes;
  
        public class GetCustomerListResponse
        {
            public int CustomerID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string CustomerPhoneNumber { get; set; }
        }
