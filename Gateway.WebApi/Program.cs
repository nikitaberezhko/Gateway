using Gateway.WebApi.Extensions;

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
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var app = builder.Build();
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        
        app.MapControllers();

        app.Run();
    }
}