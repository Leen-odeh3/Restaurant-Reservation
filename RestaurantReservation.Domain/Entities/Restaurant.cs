using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Domain.Entities;
public class Restaurant
{
    public int RestaurantID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string OperatingHours { get; set; }
    public List<Table> Tables { get; set; }
    public List<Reservation> Reservations { get; set; }
    public List<Employee> Employees { get; set; }
    public List<MenuItem> MenuItems { get; set; }
}