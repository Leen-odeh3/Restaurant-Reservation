using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Services.Abstracts;
public interface IReservationService : IEntityService<Reservation>
{
    Task<List<Reservation>> GetReservationsByCustomerId(int customerId);

}
