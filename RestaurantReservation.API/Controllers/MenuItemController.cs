using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.MenuItems.Commands.Models;
using RestaurantReservation.Core.Features.MenuItems.Queries.Models;

namespace RestaurantReservation.API.Controllers;

[ApiController]
public class MenuItemController : AppControllerBase
{
    [HttpGet("Api/V1/MenuItem/List")]
    public async Task<IActionResult> GetAllMenuItems()
    {
        var response = await Mediator.Send(new GetMenuItemListQuery());
        return Ok(response);
    }

    [HttpPost("Api/V1/MenuItem/Create")]
    public async Task<IActionResult> Create([FromBody] AddMenuItemCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("Api/V1/MenuItem/Edit")]
    public async Task<IActionResult> Edit([FromBody] EditMenuItemCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("Api/V1/MenuItem/Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new DeleteMenuItemCommand(id)));
    }
}
