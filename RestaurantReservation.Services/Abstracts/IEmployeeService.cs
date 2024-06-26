using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Domain.Enums;
namespace RestaurantReservation.Services.Abstracts;
public interface IEmployeeService : IEntityService<Employee>
{
    Task<List<Employee>> GetEmployeesByRestaurantAsync(int restaurantId);
    Task<List<Employee>> GetallManagers();
    public IQueryable<Employee> FilterPaginatedQuerable(OrderingEnum orderingEnum, string search);
}
