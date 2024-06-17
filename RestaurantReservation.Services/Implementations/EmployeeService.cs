using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Services.Implementations;
public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee> AddAsync(Employee entity)
    {
        return await _employeeRepository.AddAsync(entity);
    }

    public async Task<Employee> EditAsync(Employee entity)
    {
        var existingMenuItem = await _employeeRepository.GetByIdAsync(entity.EmployeeID);

        if (existingMenuItem != null)
        {
            existingMenuItem.FirstName = entity.FirstName;
            existingMenuItem.RestaurantID = entity.RestaurantID;
            existingMenuItem.Position= entity.Position;

            await _employeeRepository.UpdateAsync(existingMenuItem);

            return existingMenuItem;
        }
        else
        {
            throw new Exception("Employee not found");
        }
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _employeeRepository.GetListAsync();
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return await _employeeRepository.GetByIdAsync(id);
    }

    public async Task<string> DeleteAsync(Employee entity)
    {
        await _employeeRepository.DeleteAsync(entity);
        return "Success";
    }

    public async Task<List<Employee>> GetEmployeesByRestaurantAsync(int restaurantId)
    {
        return await _employeeRepository.GetEmployeesByRestaurantAsync(restaurantId);
    }

    public async Task<bool> IsNameExist(string firstName, string lastName, int id)
    {
        var result = await _employeeRepository.GetTableNoTracking()
            .FirstOrDefaultAsync(x => x.FirstName.Equals(firstName) &&
                                      x.LastName.Equals(lastName) &&
                                      !x.EmployeeID.Equals(id));

        return result != null;
    }
}
