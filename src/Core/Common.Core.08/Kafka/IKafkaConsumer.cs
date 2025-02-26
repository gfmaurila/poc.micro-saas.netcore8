namespace Common.Core._08.Kafka;

public interface IKafkaConsumer
{
    Task ConsumeAsync(IEnumerable<string> topics, string groupId, Func<string, Task> messageHandler, CancellationToken cancellationToken);
}
