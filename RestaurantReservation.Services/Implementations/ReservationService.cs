using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Services.Implementations;
public class ReservationService : IReservationService
{
    private readonly DbContext _dbContext;

    public ReservationService(DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<Reservation>> GetAllAsync()
    {
        return await _dbContext.Set<Reservation>().ToListAsync();
    }

    public async Task<Reservation> GetByIdAsync(int id)
    {
        return await _dbContext.Set<Reservation>().FindAsync(id);
    }

    public async Task<Reservation> AddAsync(Reservation entity)
    {
        _dbContext.Set<Reservation>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Reservation> EditAsync(Reservation entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<string> DeleteAsync(Reservation entity)
    {
        _dbContext.Set<Reservation>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return "Deleted successfully";
    }
}

