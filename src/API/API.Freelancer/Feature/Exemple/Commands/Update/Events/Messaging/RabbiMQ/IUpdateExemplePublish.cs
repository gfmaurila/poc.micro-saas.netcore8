using API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Update.Events.Messaging.RabbiMQ;

public interface IUpdateExemplePublish
{
    void PublishAsync(ExempleUpdateEvent events);
}
