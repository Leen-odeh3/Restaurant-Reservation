using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Services.Abstracts;
public interface IOrderService : IEntityService<Order>
{
    Task<List<Order>> GetOrdersByEmployeeId(int employeeId);

}
