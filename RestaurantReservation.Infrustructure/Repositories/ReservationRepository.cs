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
}