
using MediatR;
using RestaurantReservation.Core.Bases;

namespace RestaurantReservation.Core.Features.Tables.Commands.Models;
public class EditTableCommand : IRequest<Response<Domain.Entities.Table>>
{
    public int TableID { get; set; }
    public int RestaurantID { get; set; }
    public int Capacity { get; set; }
}
