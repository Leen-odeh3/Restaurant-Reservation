using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Services.Abstracts;
public interface IRestaurantService
{
    public Task<List<Restaurant>> GetAllRestaurantsAsync();
    public Task<Restaurant> GetByIDRestaurantsAsync(int id);
    public Task<Restaurant> AddRestaurantsAsync(Restaurant Restaurant);
    public Task<Restaurant> EditRestaurantsAsync(Restaurant Restaurant);
    public Task<bool> IsNameExist(string name,int id);
    public Task<Restaurant> DeleteRestaurantsAsync(int id);

}
