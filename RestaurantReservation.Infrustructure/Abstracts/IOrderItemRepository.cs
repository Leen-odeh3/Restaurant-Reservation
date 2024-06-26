using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Infrustructure.Abstracts;
public interface IOrderItemRepository : IGenericRepositoryAsync<OrderItem>
{
}
