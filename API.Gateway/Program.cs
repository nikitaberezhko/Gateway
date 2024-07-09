using API.Gateway.Middlewares;

namespace API.Gateway;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTransient<RoutingMiddleware>();

        var app = builder.Build();

        app.UseMiddleware<RoutingMiddleware>();

        app.Run();
    }
}