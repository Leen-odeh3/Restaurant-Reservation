using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Emoloyees.Commands.Models;
using RestaurantReservation.Core.Features.Emoloyees.Queries.Moldels;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
public class EmployeeController : AppControllerBase
{

    [HttpGet("api/v1/employee/list")]
    public async Task<IActionResult> GetAllEmployees()
    {
        var response = await Mediator.Send(new GetEmployeeListQuery());
        return Ok(response);
    }
    [HttpGet("api/v1/employee/list/manager")]
    public async Task<IActionResult> GetAllManagersEmployee()
    {
        var response = await Mediator.Send(new GetListAllManagers());
        return Ok(response);
    }

    [HttpPost("api/v1/employee/create")]
    public async Task<IActionResult> Create([FromBody] AddEmployeeCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("api/v1/employee/edit")]
    public async Task<IActionResult> Edit([FromBody] EditEmployeeCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("api/v1/employee/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await Mediator.Send(new DeleteEmployeeCommand(id));
        return NewResult(response);
    }
    [HttpGet("api/v1/employee/paginated")]
    public async Task<IActionResult> Paginated([FromQuery] GetEmployeePaginatedListQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("/api/employees/{employeeId}/averageOrderAmount")]
    public async Task<IActionResult> GetEmployeeAverageOrderAmount(int employeeId)
    {
        try
        {
            var query = new GetEmployeeAverageOrderAmountQuery(employeeId);
            var averageOrderAmount = await Mediator.Send(query);

            if (averageOrderAmount == null)
            {
                throw new Exception("Average order amount is null."); 
            }
            return Ok(averageOrderAmount);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while processing the request.", ex); 
        }
    }

}