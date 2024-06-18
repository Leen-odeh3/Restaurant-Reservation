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

    public async Task<bool> IsEmailExist(string email, int id)
    {
        var result = await _context.Customers
            .AnyAsync(x => x.Email.Equals(email) && !x.CustomerID.Equals(id));

        return result;
    }
}
