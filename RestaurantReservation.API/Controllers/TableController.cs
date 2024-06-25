using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Tables.Commands.Models;
using RestaurantReservation.Core.Features.Tables.Queries.Models;


namespace RestaurantReservation.API.Controllers;

[ApiController]
public class TableController : AppControllerBase
{
    [HttpGet("Api/V1/Table/List")]
    public async Task<IActionResult> GetAllTables()
    {
        var response = await Mediator.Send(new GetTableListQuery());
        return Ok(response);
    }

    [HttpPost("Api/V1/Table/Create")]
    public async Task<IActionResult> Create([FromBody] AddTableCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("Api/V1/Table/Edit")]
    public async Task<IActionResult> Edit([FromBody] EditTableCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("Api/V1/Table/Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new DeleteTableCommand(id)));
    }
}
