﻿using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Data;
namespace RestaurantReservation.Infrustructure.Repositories;

public class EmployeeRepository : GenericRepositoryAsync<Employee>, IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetEmployeesByRestaurantAsync(int restaurantId)
    {
        return await _context.Employees
            .Where(e => e.RestaurantID == restaurantId)
            .ToListAsync();
    }
}