using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Services.Abstracts;
public interface IRestaurantService
{
    public Task<List<Restaurant>> GetAllRestaurantsAsync();
}
