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
    [HttpGet("api/v1/order/list")]
    public async Task<IActionResult> GetAllOrders()
    {
        var response = await Mediator.Send(new GetOrderListQuery());
        return Ok(response);
    }

    [HttpPost("api/v1/order/create")]
    public async Task<IActionResult> Create([FromBody] AddOrderCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("api/v1/order/edit")]
    public async Task<IActionResult> Edit([FromBody] EditOrderCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("api/v1/order/delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await Mediator.Send(new DeleteOrderCommand(id));
        return NewResult(response);
    }
}
