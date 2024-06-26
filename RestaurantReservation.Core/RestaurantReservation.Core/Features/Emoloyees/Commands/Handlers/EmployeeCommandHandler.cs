using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Emoloyees.Commands.Models;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.Employees.Commands.Handlers;

internal class EmployeeCommandHandler : ResponseHandler,
                                        IRequestHandler<AddEmployeeCommand, Response<Employee>>,
                                        IRequestHandler<EditEmployeeCommand, Response<Employee>>,
                                        IRequestHandler<DeleteEmployeeCommand, Response<string>>
{
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;

    public EmployeeCommandHandler(IEmployeeService employeeService, IMapper mapper)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Response<Employee>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Employee>(request);

        try
        {
            var addedEmployee = await _employeeService.AddAsync(employee);
            return Success(addedEmployee);
        }
        catch (Exception ex)
        {
            return Fail<Employee>($"Failed to add employee: {ex.Message}");
        }
    }

    public async Task<Response<Employee>> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
    {
        var existingEmployee = await _employeeService.GetByIdAsync(request.EmployeeID);

        if (existingEmployee == null)
            return NotFound<Employee>("Employee not found");

        _mapper.Map(request, existingEmployee);

        try
        {
            var updatedEmployee = await _employeeService.EditAsync(existingEmployee);
            return Success(updatedEmployee);
        }
        catch (Exception ex)
        {
            return Fail<Employee>($"Failed to update employee: {ex.Message}");
        }
    }

    public async Task<Response<string>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeService.GetByIdAsync(request.Id);

        if (employee == null)
            return NotFound<string>("Employee not found");

        try
        {
            var deletionResult = await _employeeService.DeleteAsync(employee);
            return Success(deletionResult);
        }
        catch (Exception ex)
        {
            return Fail<string>($"Failed to delete employee: {ex.Message}");
        }
    }
}
