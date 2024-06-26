using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Services.Implementations;
public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper;

    public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
        _mapper = mapper;
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

        if (existingRestaurant is not null)
        {
            _mapper.Map(restaurant, existingRestaurant);
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

    public async Task<bool> IsRestaurantNameExist(string name)
    {
        var result = await _restaurantRepository.GetTableNoTracking()
          .FirstOrDefaultAsync(x => x.Name.Equals(name));

        return result is not null;
    }
}
