using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.MenuItems.Commands.Models;
using RestaurantReservation.Core.Features.MenuItems.Queries.Models;
using RestaurantReservation.Domain.AppMetaData;

namespace RestaurantReservation.API.Controllers;

[ApiController]
public class MenuItemController : AppControllerBase
{
    [HttpGet(Router.MenuItemRouting.List)]
    public async Task<IActionResult> GetAllMenuItems()
    {
        var response = await Mediator.Send(new GetMenuItemListQuery());
        return Ok(response);
    }

    [HttpPost(Router.MenuItemRouting.Create)]
    public async Task<IActionResult> Create([FromBody] AddMenuItemCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut(Router.MenuItemRouting.Edit)]
    public async Task<IActionResult> Edit([FromBody] EditMenuItemCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete(Router.MenuItemRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new DeleteMenuItemCommand(id)));
    }
}
