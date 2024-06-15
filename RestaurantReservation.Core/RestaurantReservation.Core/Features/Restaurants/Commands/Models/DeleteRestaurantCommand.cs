using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Features.Restaurants.Commands.Models;
public class DeleteRestaurantCommand : IRequest<Response<Restaurant>>
{
    public int id { get; set; }
    public DeleteRestaurantCommand(int id)
    {
        id = id;
    }
}
