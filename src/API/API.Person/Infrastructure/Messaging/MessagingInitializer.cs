using API.Exemple1.Core._08.Feature.Exemple.Commands.Create.Events.Messaging;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Delete.Events.Messaging;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Delete.Events.Messaging.Subscribe;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Update.Events.Messaging.RabbiMQ;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Update.Events.Messaging.RabbiMQ.Subscribe;
using API.Exemple1.Core._08.Feature.Notification.Messaging.RabbiMQ;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Service;
using API.Person.Feature.Notification.Messaging.RabbiMQ.Subscribe;
using API.Person.Infrastructure.Messaging.RabbiMQ;
using Common.Core._08.Interface;
using MassTransit;

namespace API.Exemple1.Core._08.Infrastructure.Messaging;

public class MessagingInitializer
{
    public static void Initialize(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        services.AddScoped<IMessageBusService, MessageBusService>();
        services.AddScoped<INotificationService, NotificationService>();

        // Publish - RabbiMQ
        services.AddScoped<INotificationRabbiMQPublish, NotificationRabbiMQPublish>();
        services.AddScoped<ICreateExemplePublish, CreateExemplePublish>();
        services.AddScoped<IUpdateExemplePublish, UpdateExemplePublish>();
        services.AddScoped<IDeleteExemplePublish, DeleteExemplePublish>();

        // Subscribe - RabbiMQ
        InitializeRabbiMQSubscribe(services, configuration);
    }


    public static void InitializeRabbiMQSubscribe(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();

        // Configuração do MassTransit com RabbitMQ
        services.AddMassTransit(cfg =>
        {
            cfg.SetKebabCaseEndpointNameFormatter();

            cfg.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration[MessagingConsts.Hostname], h =>
                {
                    h.Username(configuration[MessagingConsts.Username]);
                    h.Password(configuration[MessagingConsts.Password]);
                });

                cfg.ConfigureEndpoints(context);
            });

            // Registrar consumidores
            cfg.AddConsumer<NotificationRabbiMQSubscribe>();
            cfg.AddConsumer<CreateExempleSubscribe>();
            cfg.AddConsumer<UpdateExempleSubscribe>();
            cfg.AddConsumer<DeleteExempleSubscribe>();
        });

        //services.AddScoped<INotificationRabbiMQPublish, NotificationRabbiMQPublish>();
    }
}
