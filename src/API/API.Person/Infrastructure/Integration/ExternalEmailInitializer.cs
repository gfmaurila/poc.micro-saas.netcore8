using API.Person.Infrastructure.Integration.ExternalEmail;
using API.Person.Infrastructure.Integration.ExternalEmail.Api;
using API.Person.Infrastructure.Integration.ExternalEmail.Service;
using Refit;

namespace API.Person.Infrastructure.Integration;

public class ExternalEmailInitializer
{
    public static void Initialize(IServiceCollection services, IConfiguration conf)
    {
        services.AddRefitClient<IExternalEmailApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(conf.GetValue<string>(ExternalEmailApiConsts.BaseUrl)));
        services.AddScoped<IExternalEmailService, ExternalEmailService>();
    }
}
