using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.OrderItems.Commands;
using RestaurantReservation.Core.Features.OrderItems.Commands.Models;
using RestaurantReservation.Core.Features.OrderItems.Queries.Models;

namespace RestaurantReservation.API.Controllers;

[ApiController]
public class OrderItemController : AppControllerBase
{
    [HttpGet("api/v1/orderItem/list")]
    public async Task<IActionResult> GetAllOrderItems()
    {
        var response = await Mediator.Send(new GetOrderItemListQuery());
        return Ok(response);
    }

    [HttpPost("api/v1/orderItem/create")]
    public async Task<IActionResult> Create([FromBody] AddOrderItemCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("api/v1/orderItem/edit")]
    public async Task<IActionResult> Edit([FromBody] UpdateOrderItemCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("api/v1/orderItem/delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new DeleteOrderItemCommand(id)));
    }
}
