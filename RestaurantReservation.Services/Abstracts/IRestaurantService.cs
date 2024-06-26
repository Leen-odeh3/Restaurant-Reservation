using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Services.Abstracts;
public interface IRestaurantService : IEntityService<Restaurant>
{
    Task<bool> IsRestaurantNameExist(string name);
}
