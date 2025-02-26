using API.External.Auth.Feature.Notification.Producer;
using API.External.Auth.Feature.Notification.Service;
using Common.External.Auth.Net8.Interface;

namespace API.External.Auth.RabbiMQ;

public class RabbiMQInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IMessageBusService, MessageBusService>();
        services.AddScoped<ITwilioService, TwilioService>();

        // Publish
        services.AddScoped<ITwilioProducer, TwilioProducer>();

        // Subscribe
        // services.AddHostedService<TwilioWhatsAppConsumer>();
    }
}
