using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Reservations.Commands.Models;
using RestaurantReservation.Core.Features.Reservations.Queries.Models;
using RestaurantReservation.Core.FeaturesReservations.Commands.Models;
namespace RestaurantReservation.API.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
public class ReservationController : AppControllerBase
{
    [HttpGet("api/v1/reservation/list")]
    public async Task<IActionResult> GetAllReservations()
    {
        var response = await Mediator.Send(new GetReservationListQuery());
        return Ok(response);
    }

    [HttpPost("api/v1/reservation/create")]
    public async Task<IActionResult> Create([FromBody] AddReservationCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("api/v1/reservation/edit")]
    public async Task<IActionResult> Edit([FromBody] EditReservationCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("api/v1/reservation/delete/{id}")]
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
