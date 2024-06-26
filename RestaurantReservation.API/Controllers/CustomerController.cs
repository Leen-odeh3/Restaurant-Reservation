using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Customers.Commands.Models;
using RestaurantReservation.Core.Features.Customers.Queries.Models;
namespace RestaurantReservation.API.Controllers;

[ApiController]
public class CustomerController : AppControllerBase
{
    [HttpGet("api/v1/customer/list")]
    public async Task<IActionResult> GetAllCustomers()
    {
        var response = await Mediator.Send(new GetCustomerListQuery());
        return NewResult(response);
    }

    [HttpPost("api/v1/customer/create")]
    public async Task<IActionResult> Create([FromBody] AddCustomerCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("api/v1/customer/edit")]
    public async Task<IActionResult> Edit([FromBody] EditCustomerCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("api/v1/customer/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new DeleteCustomerCommand(id)));
    }
}
