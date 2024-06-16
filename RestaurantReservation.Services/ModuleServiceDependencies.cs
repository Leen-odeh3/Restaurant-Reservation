using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Services.Abstracts;
using RestaurantReservation.Services.Implementations;

namespace RestaurantReservation.Services;
public static class ModuleServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddTransient<IRestaurantService, RestaurantService>();
        services.AddTransient<ITableService, TableService>();

        return services;
    }
}


