using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.MenuItems.Commands.Models;
using RestaurantReservation.Core.Features.MenuItems.Queries.Models;

namespace RestaurantReservation.API.Controllers;

[ApiController]
public class MenuItemController : AppControllerBase
{
    [HttpGet("api/v1/menuItem/list")]
    public async Task<IActionResult> GetAllMenuItems()
    {
        var response = await Mediator.Send(new GetMenuItemListQuery());
        return Ok(response);
    }

    [HttpPost("api/v1/menuItem/create")]
    public async Task<IActionResult> Create([FromBody] AddMenuItemCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("api/v1/menuItem/edit")]
    public async Task<IActionResult> Edit([FromBody] EditMenuItemCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("api/v1/menuItem/delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new DeleteMenuItemCommand(id)));
    }
}
