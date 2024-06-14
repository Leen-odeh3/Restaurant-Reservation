using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Services.Implementations;
public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;
    public RestaurantService(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }

    public async Task<Restaurant> AddRestaurantsAsync(Restaurant Restaurant)
    {
      await _restaurantRepository.AddAsync(Restaurant);
        return Restaurant;

    }

    public async Task<List<Restaurant>> GetAllRestaurantsAsync()
    {
        return await _restaurantRepository.GetRestaurantsAsync();
    }

    public async Task<Restaurant> GetByIDRestaurantsAsync(int id)
    {
        var restaurant = _restaurantRepository.GetTableNoTracking()
                                        .Where(x => x.RestaurantID.Equals(id))
                                        .FirstOrDefault();
        return restaurant;
    }
}
