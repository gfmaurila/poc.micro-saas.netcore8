using Common.External.Auth.Net8.Events;

namespace Common.External.Auth.Net8.Tests.Events;

public class TestEvent : Event
{
    public TestEvent(string messageType, Guid aggregateId)
    {
        MessageType = messageType;
        AggregateId = aggregateId;
    }
}
