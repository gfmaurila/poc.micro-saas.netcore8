namespace API.Freelancer.Feature.Domain.Common;

/// <summary>
/// Defines constant event names for Exemple-related events used in messaging systems (e.g., RabbitMQ, Kafka).
/// </summary>
public static class ExempleEventConstants
{
    /// <summary>
    /// Represents the general event name for Exemple-related events.
    /// </summary>
    public const string EventExemple = "event-exemple";

    /// <summary>
    /// Represents the event name for the creation of an Exemple entity.
    /// </summary>
    public const string EventExempleCreate = "event-exemple.create";

    /// <summary>
    /// Represents the event name for the update of an Exemple entity.
    /// </summary>
    public const string EventExempleUpdate = "event-exemple.update";

    /// <summary>
    /// Represents the event name for the deletion of an Exemple entity.
    /// </summary>
    public const string EventExempleDelete = "event-exemple.delete";
}
