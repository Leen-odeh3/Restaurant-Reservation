﻿using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Infrustructure.Repositories;

namespace RestaurantReservation.Infrustructure;
public static class ModuleInfrastructureDependencies
{
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRestaurantRepository,RestaurantRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<ITableRepository, TableRepository>();
            services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderItemRepository,OrderItemRepository>();
            services.AddTransient<IReservationRepository,ReservationRepository>();

        return services;
        }
    
}