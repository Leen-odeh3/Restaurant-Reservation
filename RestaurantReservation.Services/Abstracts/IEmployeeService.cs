using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Services.Abstracts;
public interface IEmployeeService : IEntityService<Employee>
{
    Task<List<Employee>> GetEmployeesByRestaurantAsync(int restaurantId);
    Task<List<Employee>> GetallManagers();

}
