﻿using Microsoft.EntityFrameworkCore.Storage;

namespace RestaurantReservation.Infrustructure.Abstracts;
public interface IGenericRepositoryAsync<T> where T : class
{
    Task DeleteRangeAsync(ICollection<T> entities);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetListAsync();
    Task SaveChangesAsync();
    IDbContextTransaction BeginTransaction();
    void Commit();
    void RollBack();
    IQueryable<T> GetTableNoTracking();
    IQueryable<T> GetTableAsTracking();
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(ICollection<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(ICollection<T> entities);
    Task DeleteAsync(T entity);
}