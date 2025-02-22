﻿using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Data;

namespace RestaurantReservation.Infrustructure.Repositories;
public class OrderRepository : GenericRepositoryAsync<Order>, IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetListAsync()
    {
        return await _context.Orders.Include(e => e.employee).ToListAsync();
    }

    public async Task<List<OrderItem>> GetOrderItemsAsync(int orderId)
    {
        return await _context.OrderItems
            .Where(oi => oi.OrderID == orderId)
            .Include(oi => oi.Item) 
            .ToListAsync();
    }
    public Task<List<Order>> GetOrdersByEmployeeId(int employeeId)
    {
        return _context.Orders
               .Include(o => o.employee) 
               .Where(o => o.EmployeeID == employeeId)
               .ToListAsync();
    }
}
