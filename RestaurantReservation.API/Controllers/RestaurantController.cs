using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Core.Features.Restaurants.Queries.Models;

namespace RestaurantReservation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantController : ControllerBase
{
    private readonly IMediator _med;

    public RestaurantController(IMediator mediator)
    {
        _med = mediator;
    }

    [HttpGet("/Restaurant/List")]
    public async Task<IActionResult> GetAllRestaurant()
    {
        var response = await _med.Send(new GetRestaurantListQuery());
        return Ok(response);
    }

    [HttpGet("/Restaurant/{id}")]
    public async Task<IActionResult> GetByIDRestaurant([FromRoute] int id)
    {
        var response = await _med.Send(new GetRestaurantByIDQuery(id));
        return Ok(response);
    }
}
