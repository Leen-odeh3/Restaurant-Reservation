using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Data;
namespace RestaurantReservation.Infrustructure.Repositories;
public class TableRepository : GenericRepositoryAsync<Table>, ITableRepository
{
    private readonly AppDbContext _context;
    public TableRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
