using Microsoft.OpenApi.Models;

namespace API.Gateway.Configuration;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services, IConfiguration conf)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "Gateway",
                    Version = "v1"
                }
            );
        });
        return services;
    }
}
