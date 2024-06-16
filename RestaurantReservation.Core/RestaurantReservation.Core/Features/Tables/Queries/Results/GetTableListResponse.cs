namespace RestaurantReservation.Core.Features.Tables.Queries.Results;
public class GetTableListResponse 
{
    public int TableID { get; set; }
    public String RestaurantName { get; set; }
    public int Capacity { get; set; }
}
