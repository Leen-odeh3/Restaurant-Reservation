using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Infrustructure.Abstracts;
public interface IRestaurantRepository
{
   public Task<List<Restaurant>> GetRestaurantsAsync();
}
