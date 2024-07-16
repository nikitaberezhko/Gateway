using Gateway.WebApi.Extensions;
using Gateway.WebApi.Middlewares;
using Services.Services.Abstractions;
using Services.Services.Implementations;

namespace Gateway.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var services = builder.Services;

        services.AddControllers();
        
        // Extensions
        services.ConfigureApiVersioning();
        services.ConfigureRefitClients();
        services.ConfigureAutoMapper();

        services.AddScoped<IOrderService, OrderService>();
        services.AddTransient<ExceptionHandlerMiddleware>();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var app = builder.Build();

        app.UseMiddleware<ExceptionHandlerMiddleware>();
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        
        app.MapControllers();

        app.Run();
    }
}