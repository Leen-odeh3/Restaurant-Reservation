using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<Order> AddAsync(Order order)
    {
        await _orderRepository.AddAsync(order);
        return order;
    }

    public async Task<string> DeleteAsync(Order order)
    {
        var trans = _orderRepository.BeginTransaction();
        try
        {
            await _orderRepository.DeleteAsync(order);
            await trans.CommitAsync();
            return "Success";
        }
        catch (Exception ex)
        {
            await trans.RollbackAsync();
            Console.WriteLine($"Error deleting order: {ex.Message}");
            return "Failed";
        }
    }

    public async Task<Order> EditAsync(Order order)
    {
        var existingOrder = await _orderRepository.GetByIdAsync(order.OrderID);

        if (existingOrder is not null)
        {
            existingOrder.EmployeeID = order.EmployeeID;
            existingOrder.ReservationID = order.ReservationID;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.TotalAmount = order.TotalAmount;
            existingOrder.OrderItems = order.OrderItems;

            await _orderRepository.UpdateAsync(existingOrder);

            return existingOrder;
        }
        else
        {
            throw new Exception("Order not found");
        }
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _orderRepository.GetListAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }
}