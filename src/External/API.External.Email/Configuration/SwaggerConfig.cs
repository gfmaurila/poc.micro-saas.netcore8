using Microsoft.OpenApi.Models;

namespace poc.api.redis.Configuration;

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
                    Title = "Envio de mensagem E-Mail, WhatsApp",
                    Version = "v1"
                }
            );
        });
        return services;
    }
}
