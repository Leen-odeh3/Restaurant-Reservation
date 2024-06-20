using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Services.Abstracts;

public interface ICustomerService : IEntityService<Customer>
{
    Task<bool> IsEmailExist(string email, int id);
    Task<bool> IsCustomerPhoneExist(string email, int id);
}
