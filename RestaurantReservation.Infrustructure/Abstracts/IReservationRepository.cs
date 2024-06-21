using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Infrustructure.Abstracts;
public interface IReservationRepository : IGenericRepositoryAsync<Reservation>
{
    Task<List<Reservation>> GetReservationsByCustomerId(int customerId);
}

