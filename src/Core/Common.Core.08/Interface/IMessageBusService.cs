namespace Common.Core._08.Interface;
/// <summary>
/// Defines a service for interacting with a message bus, allowing publishing of messages to specific queues.
/// </summary>
public interface IMessageBusService
{
    /// <summary>
    /// Publishes a message to the specified queue.
    /// </summary>
    /// <param name="queue">The name of the queue to which the message will be published.</param>
    /// <param name="message">The message to publish, represented as a byte array.</param>
    void Publish(string queue, byte[] message);
}

