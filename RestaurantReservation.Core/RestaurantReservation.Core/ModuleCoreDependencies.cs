using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using RestaurantReservation.Core.Behaviors;
using FluentValidation;
using RestaurantReservation.Core.Bases;

namespace RestaurantReservation.Core;

public static class ModuleCoreDependencies
{
    public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
    {
       services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<ResponseHandler>();

        return services;
    }
}
