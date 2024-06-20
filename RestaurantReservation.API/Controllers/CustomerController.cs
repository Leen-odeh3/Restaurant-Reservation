using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Customers.Commands.Models;
using RestaurantReservation.Core.Features.Customers.Queries.Models;
using Router = RestaurantReservation.Domain.AppMetaData.Router;

namespace RestaurantReservation.API.Controllers;

[ApiController]
public class CustomerController : AppControllerBase
{
    [HttpGet(Router.CustomerRouting.List)]
    public async Task<IActionResult> GetAllCustomers()
    {
        var response = await Mediator.Send(new GetCustomerListQuery());
        return NewResult(response);
    }

    [HttpPost(Router.CustomerRouting.Create)]
    public async Task<IActionResult> Create([FromBody] AddCustomerCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut(Router.CustomerRouting.Edit)]
    public async Task<IActionResult> Edit([FromBody] EditCustomerCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete(Router.CustomerRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new DeleteCustomerCommand(id)));
    }
}
