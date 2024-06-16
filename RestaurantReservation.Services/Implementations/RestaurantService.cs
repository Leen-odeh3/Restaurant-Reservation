using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Services.Abstracts;
using Serilog;

namespace RestaurantReservation.Services.Implementations;
public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantService(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<Restaurant> AddAsync(Restaurant restaurant)
    {
        await _restaurantRepository.AddAsync(restaurant);
        return restaurant;
    }

    public async Task<string> DeleteAsync(Restaurant restaurant)
    {
        var trans = _restaurantRepository.BeginTransaction();
        try
        {
            await _restaurantRepository.DeleteAsync(restaurant);
            await trans.CommitAsync();
            return "Success";
        }
        catch (Exception ex)
        {
            await trans.RollbackAsync();
            Console.WriteLine($"Error deleting restaurant: {ex.Message}");
            return "Failed";
        }
    }

    public async Task<Restaurant> EditAsync(Restaurant restaurant)
    {
        var existingRestaurant = await _restaurantRepository.GetByIdAsync(restaurant.RestaurantID);

        if (existingRestaurant != null)
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

    public async Task<List<Restaurant>> GetAllAsync()
    {
        return await _restaurantRepository.GetListAsync();
    }

    public async Task<Restaurant> GetByIdAsync(int id)
    {
        return await _restaurantRepository.GetByIdAsync(id);
    }

    public async Task<bool> IsNameExist(string name, int id)
    {
        var result = await _restaurantRepository.GetTableNoTracking()
            .FirstOrDefaultAsync(x => x.Name.Equals(name) && !x.RestaurantID.Equals(id));

        return result != null;
    }
}
