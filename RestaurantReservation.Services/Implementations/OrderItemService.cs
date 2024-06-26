using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Services.Implementations;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(orderItemRepository));
    }

    public async Task<List<OrderItem>> GetAllAsync()
    {
        return await _orderItemRepository.GetListAsync();
    }

    public async Task<OrderItem> GetByIdAsync(int id)
    {
        return await _orderItemRepository.GetByIdAsync(id);
    }

    public async Task<OrderItem> AddAsync(OrderItem entity)
    {
        return await _orderItemRepository.AddAsync(entity);
    }

    public async Task<OrderItem> EditAsync(OrderItem entity)
    {
        var existingOrderItem = await _orderItemRepository.GetByIdAsync(entity.OrderItemID);
        if (existingOrderItem == null)
        {
            throw new Exception($"Order item with ID {entity.OrderItemID} not found.");
        }
        existingOrderItem.OrderID = entity.OrderID;
        existingOrderItem.MenuItemID = entity.MenuItemID;
        existingOrderItem.Quantity = entity.Quantity;

        await _orderItemRepository.UpdateAsync(existingOrderItem);

        return existingOrderItem;
    }


    public async Task<string> DeleteAsync(OrderItem entity)
    {
        var existingOrderItem = await _orderItemRepository.GetByIdAsync(entity.OrderItemID);
        if (existingOrderItem == null)
        {
            throw new Exception($"Order item with ID {entity.OrderItemID} not found.");
        }

        await _orderItemRepository.DeleteAsync(existingOrderItem);

        return "Deleted successfully";
    }
}
