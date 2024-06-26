using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Data;

namespace RestaurantReservation.Infrustructure.Repositories;
public  class MenuItemRepository : GenericRepositoryAsync<MenuItem>, IMenuItemRepository
{
    #region Fields
    private readonly AppDbContext _context;
    #endregion
    public MenuItemRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<MenuItem>> GetListAsync()
    {
        return await _context.Set<MenuItem>()
            .Include(t => t.Restaurant)
            .ToListAsync();
    }
}
