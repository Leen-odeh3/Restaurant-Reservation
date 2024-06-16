using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Services.Abstracts;
using Serilog;

namespace RestaurantReservation.Services.Implementations;
public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemService(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository ?? throw new ArgumentNullException(nameof(menuItemRepository));
    }

    public async Task<MenuItem> AddAsync(MenuItem entity)
    {
        await _menuItemRepository.AddAsync(entity);
        return entity;
    }

    public async Task<string> DeleteAsync(MenuItem entity)
    {
        var trans = _menuItemRepository.BeginTransaction();
        try
        {
            await _menuItemRepository.DeleteAsync(entity);
            await trans.CommitAsync();
            return "Success";
        }
        catch (Exception ex)
        {
            await trans.RollbackAsync();
            Console.WriteLine($"Error deleting menu item: {ex.Message}");
            return "Failed";
        }
    }

    public async Task<MenuItem> EditAsync(MenuItem entity)
    {
        var existingMenuItem = await _menuItemRepository.GetByIdAsync(entity.MenuItemID);

        if (existingMenuItem != null)
        {
            existingMenuItem.Name = entity.Name;
            existingMenuItem.Description = entity.Description;
            existingMenuItem.Price = entity.Price;

            await _menuItemRepository.UpdateAsync(existingMenuItem);

            return existingMenuItem;
        }
        else
        {
            throw new Exception("Menu item not found");
        }
    }

    public async Task<List<MenuItem>> GetAllAsync()
    {
        return await _menuItemRepository.GetListAsync();
    }

    public async Task<MenuItem> GetByIdAsync(int id)
    {
        return await _menuItemRepository.GetByIdAsync(id);
    }

    public async Task<bool> IsNameExist(string name, int id)
    {
        var result = await _menuItemRepository.GetTableNoTracking()
            .FirstOrDefaultAsync(x => x.Name.Equals(name) && !x.MenuItemID.Equals(id));

        return result != null;
    }
}
