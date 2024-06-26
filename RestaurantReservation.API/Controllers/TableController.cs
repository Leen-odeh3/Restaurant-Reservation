using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Tables.Commands.Models;
using RestaurantReservation.Core.Features.Tables.Queries.Models;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
public class TableController : AppControllerBase
{
    [HttpGet("api/v1/table/list")]
    public async Task<IActionResult> GetAllTables()
    {
        var response = await Mediator.Send(new GetTableListQuery());
        return Ok(response);
    }

    [HttpPost("api/v1/table/create")]
    public async Task<IActionResult> Create([FromBody] AddTableCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("api/v1/table/edit")]
    public async Task<IActionResult> Edit([FromBody] EditTableCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("api/v1/table/delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new DeleteTableCommand(id)));
    }
}
