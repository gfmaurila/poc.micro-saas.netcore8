using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Poc.Twilio.API.Extensions;

public static class WebApplicationExtensions
{
    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Poc.Twilio.API",
                Version = "v1",
                Description = "Api de autenticação de usuários",
                Contact = new OpenApiContact
                {
                    Name = "Guilherme Figueiras Maurila",
                    Email = "gfmaurila@gmail.com"
                },
            });

            // Adicione este bloco para filtrar controladores por versão
            c.DocInclusionPredicate((version, apiDescription) =>
            {
                if (version == "v1" && apiDescription.RelativePath.Contains("api/v1/"))
                    return true;

                return false;
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });


    }

    public static void UseDevelopmentSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Poc.Twilio.API");
        });
    }
}
