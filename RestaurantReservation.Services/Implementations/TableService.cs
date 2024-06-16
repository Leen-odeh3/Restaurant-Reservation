using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Repositories;
using RestaurantReservation.Services.Abstracts;
using Serilog;
namespace RestaurantReservation.Services.Implementations;
public class TableService : ITableService
{
    private readonly ITableRepository _tableRepository;
    public TableService(ITableRepository tableRepository)
    {
       _tableRepository = tableRepository;
    }
    public async Task<Table> AddTablesAsync(Table Table)
    {
        await _tableRepository.AddAsync(Table);
        return Table;
    }

    public async Task<string> DeleteAsync(Table Table)
    {
        var trans = _tableRepository.BeginTransaction();
        try
        {
            await _tableRepository.DeleteAsync(Table);
            await trans.CommitAsync();
            return "Success";
        }
        catch (Exception ex)
        {
            await trans.RollbackAsync();
            Log.Error(ex.Message);
            return "Falied";
        }
    }

    public async Task<Table> EditTablesAsync(Table Table)
    {
        var existingTable = await _tableRepository.GetByIdAsync(Table.TableID);

        if (existingTable is not null)
        {

            existingTable.Capacity = Table.Capacity;
            existingTable.RestaurantID =Table.RestaurantID;

            await _tableRepository.UpdateAsync(existingTable);

            return existingTable;
        }
        else
        {
            throw new Exception("Table not found");
        }
    }

    public async Task<List<Table>> GetAllTablesAsync()
    {
        return await _tableRepository.GetListAsync();
    }

    public async Task<Table> GetByIDTableAsync(int id)
    {
        return await _tableRepository.GetByIdAsync(id); 
    }
}

