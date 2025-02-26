using API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Create.Events.Messaging;

public interface ICreateExemplePublish
{
    void PublishAsync(ExempleCreateEvent events);
}
