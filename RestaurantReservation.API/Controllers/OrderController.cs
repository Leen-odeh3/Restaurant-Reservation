using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Orders.Commands.Models;
using RestaurantReservation.Core.Features.Orders.Queries.Models;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
public class OrderController : AppControllerBase
{
    [HttpGet("Api/V1/Order/List")]
    public async Task<IActionResult> GetAllOrders()
    {
        var response = await Mediator.Send(new GetOrderListQuery());
        return Ok(response);
    }

    [HttpPost("Api/V1/Order/Create")]
    public async Task<IActionResult> Create([FromBody] AddOrderCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("Api/V1/Order/Edit")]
    public async Task<IActionResult> Edit([FromBody] EditOrderCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("Api/V1/Order/Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await Mediator.Send(new DeleteOrderCommand(id));
        return NewResult(response);
    }
}
