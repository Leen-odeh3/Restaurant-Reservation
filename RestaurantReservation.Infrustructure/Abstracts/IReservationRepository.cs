using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Infrustructure.Abstracts;
public interface IReservationRepository : IGenericRepositoryAsync<Reservation>
{ }

