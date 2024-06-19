using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Data;
namespace RestaurantReservation.Infrustructure.Repositories;

internal class OrderItemRepository : GenericRepositoryAsync<OrderItem>, IOrderItemRepository
{
    private readonly AppDbContext _context;

    public OrderItemRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<OrderItem>> GetListAsync()
    {
        return await _context.OrderItems.
            Include(e => e.Order).ThenInclude(m=>m.reservation).
            ThenInclude(m => m.restaurant).ToListAsync();
    }
}
