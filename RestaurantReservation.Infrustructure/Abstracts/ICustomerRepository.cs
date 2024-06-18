using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Infrustructure.Abstracts;

public interface ICustomerRepository : IGenericRepositoryAsync<Customer>
{
    Task<bool> IsEmailExist(string email, int id);
}
