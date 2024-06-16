namespace RestaurantReservation.Services.Abstracts;
public interface IEntityService<TEntity>
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> EditAsync(TEntity entity);
    Task<string> DeleteAsync(TEntity entity);
}
