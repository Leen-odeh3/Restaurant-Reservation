using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Data;
namespace RestaurantReservation.Infrustructure.Repositories;

public class CustomerRepository : GenericRepositoryAsync<Customer>, ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<Customer>> GetListAsync()
    {
        return await _context.Customers.Include(e => e.Reservations)
            .ThenInclude(xx=>xx.Table).ThenInclude(xx=>xx.Restaurant)
            .AsSplitQuery().ToListAsync();
    }
}
