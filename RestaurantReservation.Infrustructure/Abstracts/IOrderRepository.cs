using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Infrustructure.Abstracts;
public interface IOrderRepository : IGenericRepositoryAsync<Order>
{
    Task<List<OrderItem>> GetOrderItemsAsync(int orderId);
    Task<List<Order>> GetOrdersByEmployeeId(int employeeId);
}

