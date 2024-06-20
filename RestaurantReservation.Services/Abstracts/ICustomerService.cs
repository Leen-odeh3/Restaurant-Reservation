using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Services.Abstracts;

public interface ICustomerService : IEntityService<Customer>
{
    Task<bool> IsEmailExist(string email);
    Task<bool> IsCustomerPhoneExist(string phone);
}
