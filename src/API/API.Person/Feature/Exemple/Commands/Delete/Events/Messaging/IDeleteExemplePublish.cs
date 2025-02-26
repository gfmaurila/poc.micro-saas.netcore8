using API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Delete.Events.Messaging;

public interface IDeleteExemplePublish
{
    void PublishAsync(ExempleDeleteEvent events);
}
