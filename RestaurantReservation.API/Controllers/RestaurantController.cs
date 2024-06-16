using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Restaurants.Commands.Models;
using RestaurantReservation.Core.Features.Restaurants.Queries.Models;
using RestaurantReservation.Domain.AppMetaData;

namespace RestaurantReservation.API.Controllers;

[ApiController]
public class RestaurantController : AppControllerBase
{
    public RestaurantController()
    {
    
    }

    [HttpGet(Router.RestaurantRouting.List)]
    public async Task<IActionResult> GetAllRestaurant()
    {
        var response = await Mediator.Send(new GetRestaurantListQuery());
        return Ok(response);
    }

    [HttpGet(Router.RestaurantRouting.GetByID)]
    public async Task<IActionResult> GetByIDRestaurant([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetRestaurantByIDQuery(id));
        return NewResult(response);
    }
    [HttpPost(Router.RestaurantRouting.Create)]
    public async Task<IActionResult> Create([FromBody] AddRestaurantCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.RestaurantRouting.Edit)]
    public async Task<IActionResult> Edit([FromBody] EditRestaurantCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete(Router.RestaurantRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new DeleteRestaurantCommand(id)));
    }

}
