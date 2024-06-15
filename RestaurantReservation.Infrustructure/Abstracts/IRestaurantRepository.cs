using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Infrustructure.Abstracts;
public interface IRestaurantRepository : IGenericRepositoryAsync<Restaurant>
{
   public Task<List<Restaurant>> GetRestaurantsAsync();

}
