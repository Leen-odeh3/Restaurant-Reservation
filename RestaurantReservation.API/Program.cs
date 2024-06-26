using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Core;
using RestaurantReservation.Core.MiddleWare;
using RestaurantReservation.Infrustructure;
using RestaurantReservation.Infrustructure.Data;
using RestaurantReservation.Services;


namespace RestaurantReservation.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddDbContext<AppDbContext>(option =>
        {
            option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        #region Dependency injections

        builder.Services.AddInfrastructureDependencies()
                        .AddServiceDependencies()
                        .AddCoreDependencies();                         
        #endregion

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseMiddleware<ErrorHandlerMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
