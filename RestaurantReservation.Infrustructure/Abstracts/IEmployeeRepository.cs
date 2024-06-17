using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Infrustructure.Abstracts;
public interface IEmployeeRepository : IGenericRepositoryAsync<Employee>
{
    Task<List<Employee>> GetEmployeesByRestaurantAsync(int restaurantId);
}
