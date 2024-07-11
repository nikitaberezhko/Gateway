using API.Gateway.Handlers;
using API.Gateway.Infrastructure;
using API.Gateway.Settings;

namespace API.Gateway;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;
        services.Configure<RouterSettings>(builder.Configuration.GetSection("RouterSettings"));
        
        services.AddHttpClient();
        services.AddScoped<RequestSerializer>();
        services.AddScoped<Router>();
        services.AddScoped<RoutingHandler>();
        
        var app = builder.Build();
        
        app.UseRouting();
        
        app.Run(async context =>
        {
            using var serviceScope = app.Services.CreateScope();
            
            var handler = serviceScope.ServiceProvider.GetService<RoutingHandler>();
            await handler!.Routing(context);
        });
        app.Run();
    }
}