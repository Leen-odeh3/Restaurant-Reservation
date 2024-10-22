﻿using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Services.Abstracts;
using RestaurantReservation.Services.Implementations;

namespace RestaurantReservation.Services;
public static class ModuleServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddTransient<IRestaurantService, RestaurantService>();
        services.AddTransient<ITableService, TableService>();
        services.AddTransient<IMenuItemService, MenuItemService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IReservationService, ReservationService>();



        return services;
    }
}


