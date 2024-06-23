using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Domain.Enums;
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

        if (existingMenuItem is not null)
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

        return result is not null;
    }
    public async Task<List<Employee>> GetallManagers()
    {
        var managers = await _employeeRepository.GetListallmanagers();
        return managers;
    }
    public IQueryable<Employee> FilterPaginatedQuerable(OrderingEnum orderingEnum, string search)
    {
        var querable = _employeeRepository.GetTableNoTracking().Include(x => x.Restaurant).AsQueryable();
        if (search is not null)
        {
            querable = querable.Where(x => x.FirstName.Contains(search) || x.Restaurant.Name.Contains(search));
        }
        switch (orderingEnum)
        {
            case OrderingEnum.EmployeeID:
                querable = querable.OrderBy(x =>x.EmployeeID);
                break;
            case OrderingEnum.FirstName:
                querable = querable.OrderBy(x => x.FirstName);
                break;
            case OrderingEnum.RestaurantName:
                querable = querable.OrderBy(x => x.Restaurant.Name);
                break;
            case OrderingEnum.LastName:
                querable = querable.OrderBy(x => x.LastName);
                break;
        }

        return querable;
    }
}
