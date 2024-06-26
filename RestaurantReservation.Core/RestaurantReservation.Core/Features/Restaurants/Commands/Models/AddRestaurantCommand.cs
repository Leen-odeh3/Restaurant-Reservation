using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Restaurants.Queries.Results;
namespace RestaurantReservation.Core.Features.Restaurants.Commands.Models;
public class AddRestaurantCommand: IRequest<Response<Domain.Entities.Restaurant>>
{
    public string RestaurantName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string OperatingHours { get; set; }
}
