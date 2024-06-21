using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Base;
using RestaurantReservation.Core.Features.Emoloyees.Commands.Models;
using RestaurantReservation.Core.Features.Emoloyees.Queries.Moldels;
using RestaurantReservation.Domain.AppMetaData;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    public class EmployeeController : AppControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EmployeeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet(Router.EmployeeRouting.List)]
        public async Task<IActionResult> GetAllEmployees()
        {
            var response = await _mediator.Send(new GetEmployeeListQuery());
            return Ok(response);
        }
        [HttpGet(Router.EmployeeRouting.manager)]
        public async Task<IActionResult> GetAllManagersEmployee()
        {
            var response = await _mediator.Send(new GetListAllManagers());
            return Ok(response);
        }

        [HttpPost(Router.EmployeeRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddEmployeeCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.EmployeeRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditEmployeeCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.EmployeeRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteEmployeeCommand(id));
            return NewResult(response);
        }

        [HttpGet("/api/employees/{employeeId}/averageOrderAmount")]
        public async Task<IActionResult> GetEmployeeAverageOrderAmount(int employeeId)
        {
            try
            {
                var query = new GetEmployeeAverageOrderAmountQuery(employeeId);
                var averageOrderAmount = await _mediator.Send(query);
                return Ok(averageOrderAmount);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}