using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Data;

namespace RestaurantReservation.Infrustructure.Repositories;

internal class ReservationRepository : GenericRepositoryAsync<Reservation>, IReservationRepository
{
    private readonly AppDbContext _context;

    public ReservationRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<Reservation>> GetListAsync()
    {
        return await _context.Reservations.Include(e => e.customer).Include(m=>m.restaurant).ToListAsync();
    }
    public async Task<List<Reservation>> GetReservationsByCustomerId(int customerId)
    {
        return await _context.Reservations.Include(xx=>xx.restaurant)
                             .Include(c=>c.customer)
                             .Where(r => r.CustomerID == customerId)
                             .ToListAsync();
    }
}