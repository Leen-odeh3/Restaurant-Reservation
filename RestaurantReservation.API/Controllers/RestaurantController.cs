using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Core.Features.Restaurants.Queries.Models;
using RestaurantReservation.Domain.AppMetaData;

namespace RestaurantReservation.API.Controllers;

[ApiController]
public class RestaurantController : ControllerBase
{
    private readonly IMediator _med;

    public RestaurantController(IMediator mediator)
    {
        _med = mediator;
    }

    [HttpGet(Router.RestaurantRouting.List)]
    public async Task<IActionResult> GetAllRestaurant()
    {
        var response = await _med.Send(new GetRestaurantListQuery());
        return Ok(response);
    }

    [HttpGet(Router.RestaurantRouting.GetByID)]
    public async Task<IActionResult> GetByIDRestaurant([FromRoute] int id)
    {
        var response = await _med.Send(new GetRestaurantByIDQuery(id));
        return Ok(response);
    }
}
