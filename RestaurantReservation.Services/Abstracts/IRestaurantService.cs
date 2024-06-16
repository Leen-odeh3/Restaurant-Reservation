using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Services.Abstracts;
public interface IRestaurantService : IEntityService<Restaurant>
{
    Task<bool> IsNameExist(string name, int id);
}
