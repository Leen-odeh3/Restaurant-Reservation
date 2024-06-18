using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Services.Implementations;
public class OrderItemService : IOrderItemService
{
    private readonly DbContext _dbContext;

    public OrderItemService(DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<OrderItem>> GetAllAsync()
    {
        return await _dbContext.Set<OrderItem>().ToListAsync();
    }

    public async Task<OrderItem> GetByIdAsync(int id)
    {
        return await _dbContext.Set<OrderItem>().FindAsync(id);
    }

    public async Task<OrderItem> AddAsync(OrderItem entity)
    {
        _dbContext.Set<OrderItem>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<OrderItem> EditAsync(OrderItem entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<string> DeleteAsync(OrderItem entity)
    {
        _dbContext.Set<OrderItem>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return "Deleted successfully";
    }
}