using Gateway.WebApi.Extensions;
using Gateway.WebApi.Middlewares;

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