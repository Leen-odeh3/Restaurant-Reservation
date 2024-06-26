using MediatR;
using RestaurantReservation.Core.Bases;

namespace RestaurantReservation.Core.Features.Restaurants.Commands.Models;
public class EditRestaurantCommand : IRequest<Response<Domain.Entities.Restaurant>>
{
    public int Id { get; set; }
    public string RestaurantName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string OperatingHours { get; set; }
}

