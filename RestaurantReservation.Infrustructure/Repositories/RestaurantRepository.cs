using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Data;

namespace RestaurantReservation.Infrustructure.Repositories;
public class RestaurantRepository : GenericRepositoryAsync<Restaurant> ,IRestaurantRepository 
{
    private readonly AppDbContext _context;
    public RestaurantRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
