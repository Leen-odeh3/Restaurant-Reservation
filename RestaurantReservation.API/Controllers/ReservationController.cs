using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Reservations.Commands.Models;
using RestaurantReservation.Core.Features.Reservations.Queries.Models;
using RestaurantReservation.Core.FeaturesReservations.Commands.Models;
using RestaurantReservation.Domain.AppMetaData;

namespace RestaurantReservation.API.Controllers;

[ApiController]
public class ReservationController : AppControllerBase
{
    [HttpGet(Router.ReservationRouting.List)]
    public async Task<IActionResult> GetAllReservations()
    {
        var response = await Mediator.Send(new GetReservationListQuery());
        return Ok(response);
    }

    [HttpPost(Router.ReservationRouting.Create)]
    public async Task<IActionResult> Create([FromBody] AddReservationCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut(Router.ReservationRouting.Edit)]
    public async Task<IActionResult> Edit([FromBody] EditReservationCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete(Router.ReservationRouting.Delete)]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await Mediator.Send(new DeleteReservationCommand(id));
        return NewResult(response);
    }

    [HttpGet("reservations/customer/{customerId}")]
    public async Task<ActionResult<List<IActionResult>>> GetReservationsByCustomerId(int customerId)
    {
        var query = new GetReservationsByCustomerQuery(customerId);
        var reservations = await Mediator.Send(query);

        if (reservations is null || reservations.Count == 0)
        {
            return NotFound("No reservations found for the customer.");
        }

        return Ok(reservations);
    }
}
