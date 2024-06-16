using RestaurantReservation.Domain.Entities;
namespace RestaurantReservation.Services.Abstracts;
public interface ITableService
{
    public Task<List<Table>> GetAllTablesAsync();
    public Task<Table> GetByIDTableAsync(int id);
    public Task<Table> AddTablesAsync(Table Table);
    public Task<Table> EditTablesAsync(Table Table);
    public Task<string> DeleteAsync(Table Table);
}
