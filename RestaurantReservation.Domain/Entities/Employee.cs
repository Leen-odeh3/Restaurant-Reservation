using RestaurantReservation.Domain.Enums;
namespace RestaurantReservation.Domain.Entities;
public class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmployeePosition Position { get; set; }
    public int RestaurantID { get; set; }
    public Restaurant Restaurant { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

}
