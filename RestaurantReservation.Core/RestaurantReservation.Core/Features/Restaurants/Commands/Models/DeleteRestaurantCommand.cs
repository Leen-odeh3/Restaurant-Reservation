using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Features.Restaurants.Commands.Models;
public class DeleteRestaurantCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public DeleteRestaurantCommand(int id)
    {
        Id = id;
    }
}
