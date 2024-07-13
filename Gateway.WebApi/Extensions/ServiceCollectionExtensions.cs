using Asp.Versioning;
using Gateway.WebApi.RefitClients;
using Refit;

namespace Gateway.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApiVersioning(
        this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }

    public static IServiceCollection ConfigureRefitClients(
        this IServiceCollection services)
    {
        services.AddRefitClient<IIdentityApi>(new RefitSettings()
            {
                ExceptionFactory = httpResponse => Task.FromResult<Exception>(null),
            })
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:8080"));
        
        services.AddRefitClient<ITrackingApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:8082"));
        
        services.AddRefitClient<IOrderApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:8084"));
        
        services.AddRefitClient<IWorkUnitApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:8084"));

        return services;
    }
}