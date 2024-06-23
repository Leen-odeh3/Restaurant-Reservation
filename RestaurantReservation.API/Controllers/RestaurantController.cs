using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Restaurants.Commands.Models;
using RestaurantReservation.Core.Features.Restaurants.Queries.Models;
using RestaurantReservation.Domain.AppMetaData;

namespace RestaurantReservation.API.Controllers;

[ApiController]
public class RestaurantController : AppControllerBase
{
    [HttpGet("Api/V1/Restaurant/List")]
    public async Task<IActionResult> GetAllRestaurant()
    {
        var response = await Mediator.Send(new GetRestaurantListQuery());
        return Ok(response);
    }

    [HttpGet("Api/V1/Restaurant/{id}")]
    public async Task<IActionResult> GetByIDRestaurant([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetRestaurantByIDQuery(id));
        return NewResult(response);
    }
    [HttpPost("Api/V1/Restaurant/Create")]
    public async Task<IActionResult> Create([FromBody] AddRestaurantCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut("Api/V1/Restaurant/Edit")]
    public async Task<IActionResult> Edit([FromBody] EditRestaurantCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("Api/V1/Restaurant/Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new DeleteRestaurantCommand(id)));
    }

}
