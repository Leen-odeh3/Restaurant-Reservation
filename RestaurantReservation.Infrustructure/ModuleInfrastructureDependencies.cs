using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Repositories;

namespace RestaurantReservation.Infrustructure;
public static class ModuleInfrastructureDependencies
{
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRestaurantRepository,RestaurantRepository>();
          

            return services;
        }
    
}