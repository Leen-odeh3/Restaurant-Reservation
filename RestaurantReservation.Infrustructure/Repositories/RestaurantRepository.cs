﻿using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Data;

namespace RestaurantReservation.Infrustructure.Repositories;
public class RestaurantRepository : GenericRepositoryAsync<Restaurant> ,IRestaurantRepository 
{
    #region Fields
    private readonly AppDbContext _context;
    #endregion
    public RestaurantRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<Restaurant>> GetRestaurantsAsync()
    {
       return await _context.Restaurants.ToListAsync();
    }
}
