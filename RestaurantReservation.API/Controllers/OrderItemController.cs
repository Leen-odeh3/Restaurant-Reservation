using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.OrderItems.Commands;
using RestaurantReservation.Core.Features.OrderItems.Commands.Models;
using RestaurantReservation.Core.Features.OrderItems.Queries.Models;
using RestaurantReservation.Domain.AppMetaData;

namespace RestaurantReservation.API.Controllers;

[ApiController]
public class OrderItemController : AppControllerBase
{
    [HttpGet("Api/V1/OrderItem/List")]
    public async Task<IActionResult> GetAllOrderItems()
    {
        var response = await Mediator.Send(new GetOrderItemListQuery());
        return Ok(response);
    }

    [HttpPost("Api/V1/OrderItem/Create")]
    public async Task<IActionResult> Create([FromBody] AddOrderItemCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("Api/V1/OrderItem/Edit")]
    public async Task<IActionResult> Edit([FromBody] UpdateOrderItemCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("Api/V1/OrderItem/Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new DeleteOrderItemCommand(id)));
    }
}
