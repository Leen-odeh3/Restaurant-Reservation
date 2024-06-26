using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Features.Tables.Commands.Models;
public class AddTableCommand : IRequest<Response<Table>>
{
    public int RestaurantID { get; set; }
    public int Capacity { get; set; }
}
