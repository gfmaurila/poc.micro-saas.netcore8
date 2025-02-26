namespace API.Exemple1.Core._08.Infrastructure.Messaging;

/// <summary>
/// Defines constant values for messaging configurations, including RabbitMQ and Kafka.
/// These constants are used to retrieve connection settings from the application configuration.
/// </summary>
public class MessagingConsts
{
    #region RabbitMQ Configuration Keys

    /// <summary>
    /// Configuration key for RabbitMQ hostname.
    /// </summary>
    public const string Hostname = "RabbitMQ:Hostname";

    /// <summary>
    /// Configuration key for RabbitMQ port.
    /// </summary>
    public const string Port = "RabbitMQ:Port";

    /// <summary>
    /// Configuration key for RabbitMQ username.
    /// </summary>
    public const string Username = "RabbitMQ:Username";

    /// <summary>
    /// Configuration key for RabbitMQ password.
    /// </summary>
    public const string Password = "RabbitMQ:Password";

    /// <summary>
    /// Configuration key for RabbitMQ virtual host.
    /// </summary>
    public const string VirtualHost = "RabbitMQ:VirtualHost";

    #endregion

    #region Kafka Configuration Keys

    /// <summary>
    /// Configuration key for Kafka bootstrap servers (broker connection).
    /// </summary>
    public const string HostnameKafka = "Kafka:BootstrapServers";

    /// <summary>
    /// Configuration key for Kafka default topic.
    /// </summary>
    public const string HostnameKafkaDefaultTopic = "Kafka:DefaultTopic";

    #endregion
}
