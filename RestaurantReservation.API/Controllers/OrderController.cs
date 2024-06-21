using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Orders.Commands.Models;
using RestaurantReservation.Core.Features.Orders.Queries.Models;
using RestaurantReservation.Domain.AppMetaData;

namespace RestaurantReservation.API.Controllers;

[ApiController]
public class OrderController : AppControllerBase
{
    [HttpGet(Router.OrderRouting.List)]
    public async Task<IActionResult> GetAllOrders()
    {
        var response = await Mediator.Send(new GetOrderListQuery());
        return Ok(response);
    }

    [HttpPost(Router.OrderRouting.Create)]
    public async Task<IActionResult> Create([FromBody] AddOrderCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut(Router.OrderRouting.Edit)]
    public async Task<IActionResult> Edit([FromBody] EditOrderCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete(Router.OrderRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await Mediator.Send(new DeleteOrderCommand(id));
        return NewResult(response);
    }
}
