using Microsoft.Extensions.DependencyInjection;
using Poc.Auth.Twilio.Interfaces;
using Poc.Auth.Twilio.Services;

namespace Poc.Auth;

public class IntegrationApisInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<ITwilioService, TwilioService>();
    }
}

