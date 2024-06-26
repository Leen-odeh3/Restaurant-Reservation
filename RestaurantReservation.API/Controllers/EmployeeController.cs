using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Emoloyees.Commands.Models;
using RestaurantReservation.Core.Features.Emoloyees.Queries.Moldels;

namespace RestaurantReservation.API.Controllers;

[ApiController]
public class EmployeeController : AppControllerBase
{

    [HttpGet("Api/V1/Employee/List")]
    public async Task<IActionResult> GetAllEmployees()
    {
        var response = await Mediator.Send(new GetEmployeeListQuery());
        return Ok(response);
    }
    [HttpGet("Api/V1/Employee/List/Manager")]
    public async Task<IActionResult> GetAllManagersEmployee()
    {
        var response = await Mediator.Send(new GetListAllManagers());
        return Ok(response);
    }

    [HttpPost("Api/V1/Employee/Create")]
    public async Task<IActionResult> Create([FromBody] AddEmployeeCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("Api/V1/Employee/Edit")]
    public async Task<IActionResult> Edit([FromBody] EditEmployeeCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("Api/V1/Employee/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await Mediator.Send(new DeleteEmployeeCommand(id));
        return NewResult(response);
    }
    [HttpGet("Api/V1/Employee/Paginated")]
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