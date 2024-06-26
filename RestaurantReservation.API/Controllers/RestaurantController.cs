using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Restaurants.Commands.Models;
using RestaurantReservation.Core.Features.Restaurants.Queries.Models;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
public class RestaurantController : AppControllerBase
{
    [HttpGet("api/v1/restaurant/list")]
    public async Task<IActionResult> GetAllRestaurant()
    {
        var response = await Mediator.Send(new GetRestaurantListQuery());
        return Ok(response);
    }

    [HttpGet("api/v1/restaurant/{id}")]
    public async Task<IActionResult> GetByIDRestaurant([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetRestaurantByIDQuery(id));
        return NewResult(response);
    }
    [HttpPost("api/v1/restaurant/create")]
    public async Task<IActionResult> Create([FromBody] AddRestaurantCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut("api/v1/restaurant/edit")]
    public async Task<IActionResult> Edit([FromBody] EditRestaurantCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("api/v1/restaurant/delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new DeleteRestaurantCommand(id)));
    }

}
