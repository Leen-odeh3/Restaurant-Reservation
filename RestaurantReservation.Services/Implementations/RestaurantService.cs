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
    public Task<List<Restaurant>> GetAllRestaurantsAsync()
    {
        return _restaurantRepository.GetRestaurantsAsync();
    }
}
