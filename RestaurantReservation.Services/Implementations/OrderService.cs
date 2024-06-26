using AutoMapper;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Repositories;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
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

        if (existingOrder is null)
        {
            throw new Exception($"Order with ID {order.OrderID} not found.");
        }

        existingOrder.OrderItems.Clear();
        foreach (var item in order.OrderItems)
        {
            existingOrder.OrderItems.Add(item);
        }

        _mapper.Map(order, existingOrder);
        await _orderRepository.UpdateAsync(existingOrder);

        return existingOrder;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        var orders = await _orderRepository.GetListAsync();

        foreach (var order in orders)
        {
            order.TotalAmount = await CalculateTotalAmount(order.OrderID); 
        }

        return orders;
    }
    private async Task<decimal> CalculateTotalAmount(int orderId)
    {
        var orderItems = await _orderRepository.GetOrderItemsAsync(orderId);
        var totalAmount = 0m;

        foreach (var item in orderItems)
        {
           var itemQuantity = (decimal)item.Quantity;
           var itemPrice = (decimal)item.Item.Price;

           var itemTotal = itemQuantity * itemPrice;

            totalAmount += itemTotal;
        }

        return totalAmount;
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public Task<List<Order>> GetOrdersByEmployeeId(int employeeId)
    {
        return _orderRepository.GetOrdersByEmployeeId(employeeId);
    }

}