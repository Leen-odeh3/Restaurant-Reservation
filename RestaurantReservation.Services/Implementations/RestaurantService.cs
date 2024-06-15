using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Repositories;
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

    public async Task<Restaurant> EditRestaurantsAsync(Restaurant restaurant)
    { 
     var existingRestaurant = await _restaurantRepository.GetByIdAsync(restaurant.RestaurantID);

            if (existingRestaurant is not null)
            {
              
                existingRestaurant.Name = restaurant.Name;
                existingRestaurant.Address = restaurant.Address;
                existingRestaurant.PhoneNumber = restaurant.PhoneNumber;
                existingRestaurant.OperatingHours = restaurant.OperatingHours;

                await _restaurantRepository.UpdateAsync(existingRestaurant);

                return existingRestaurant;
            }
            else
            {
                throw new Exception("Restaurant not found");
            }
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

    public async Task<bool> IsNameExist(string name, int id)
    {
        var result = await _restaurantRepository.GetTableNoTracking().Where(x => x.Name.Equals(name) & !x.RestaurantID.Equals(id)).FirstOrDefaultAsync();
        if (result is null) return false;
        return true;
    }

}
