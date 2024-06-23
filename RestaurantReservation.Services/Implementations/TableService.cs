using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Services.Abstracts;
namespace RestaurantReservation.Services.Implementations;
public class TableService : ITableService
{
    private readonly ITableRepository _tableRepository;

    public TableService(ITableRepository tableRepository)
    {
        _tableRepository = tableRepository ?? throw new ArgumentNullException(nameof(tableRepository));
    }

    public async Task<Table> AddAsync(Table table)
    {
        await _tableRepository.AddAsync(table);
        return table;
    }

    public async Task<string> DeleteAsync(Table table)
    {
        var trans = _tableRepository.BeginTransaction();
        try
        {
            await _tableRepository.DeleteAsync(table);
            await trans.CommitAsync();
            return "Success";
        }
        catch (Exception ex)
        {
            await trans.RollbackAsync();
            Console.WriteLine($"Error deleting table: {ex.Message}");
            return "Failed";
        }
    }

    public async Task<Table> EditAsync(Table table)
    {
        var existingTable = await _tableRepository.GetByIdAsync(table.TableID);

        if (existingTable is not null)
        {
            existingTable.Capacity = table.Capacity;
            existingTable.RestaurantID = table.RestaurantID;

            await _tableRepository.UpdateAsync(existingTable);

            return existingTable;
        }
        else
        {
            throw new Exception("Table not found");
        }
    }

    public async Task<List<Table>> GetAllAsync()
    {
        return await _tableRepository.GetListAsync();
    }

    public async Task<Table> GetByIdAsync(int id)
    {
        return await _tableRepository.GetByIdAsync(id);
    }
}

