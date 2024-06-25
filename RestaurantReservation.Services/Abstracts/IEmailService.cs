using RestaurantReservation.Domain.Identity;
namespace RestaurantReservation.Services.Abstracts;
public interface IEmailService
{
    void SendEmail(Message message);
}
