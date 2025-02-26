using API.Customer.Feature.Notification.Messaging.Kafka.Subscribe;
using API.Customer.Feature.Notification.Messaging.RabbiMQ.Subscribe;
using API.Customer.Infrastructure.Messaging.RabbiMQ;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Create.Events.Messaging;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Delete.Events.Messaging;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Delete.Events.Messaging.Subscribe;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Update.Events.Messaging.RabbiMQ;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Update.Events.Messaging.RabbiMQ.Subscribe;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Kafka;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Kafka.Subscribe;
using API.Exemple1.Core._08.Feature.Notification.Messaging.RabbiMQ;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Service;
using Common.Core._08.Interface;
using Common.Core._08.Kafka;
using Microsoft.Extensions.Options;

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
        services.AddHostedService<NotificationRabbiMQSubscribe>();
        services.AddHostedService<CreateExempleSubscribe>();
        services.AddHostedService<UpdateExempleSubscribe>();
        services.AddHostedService<DeleteExempleSubscribe>();

        // Publish - Kafka
        services.AddScoped<INotificationKafkaPublish, NotificationKafkaPublish>();

        // Subscribe - Kafka
        // Configuração do Kafka
        services.Configure<KafkaConsumerConfig>(configuration.GetSection("Kafka"));

        // Registrar a configuração como um singleton para ser usada diretamente
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<KafkaConsumerConfig>>().Value);

        // Registrar o KafkaConsumer
        services.AddSingleton<IKafkaConsumer, KafkaConsumer>();

        // Registrar o processador de mensagens como scoped
        services.AddScoped<INotificationMessageProcessor, NotificationMessageProcessor>();

        // Registrar o NotificationKafkaSubscribe como hosted service (singleton)
        services.AddHostedService<NotificationKafkaSubscribe>();

    }
}
