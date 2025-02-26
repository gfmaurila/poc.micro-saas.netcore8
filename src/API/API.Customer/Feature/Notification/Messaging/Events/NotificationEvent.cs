using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Domain.Events;

namespace API.Exemple1.Core._08.Feature.Notification.Messaging.Events;

public class NotificationEvent : Event
{
    public NotificationEvent(ENotificationType notificationType, string from, string body, string to, Guid aggregateId)
    {
        if (string.IsNullOrEmpty(from))
            throw new ArgumentException("From cannot be null or empty.");
        if (string.IsNullOrEmpty(body))
            throw new ArgumentException("Body cannot be null or empty.");
        if (string.IsNullOrEmpty(to))
            throw new ArgumentException("To cannot be null or empty.");

        NotificationType = notificationType;
        From = from;
        Body = body;
        To = to;
        AggregateId = aggregateId;
        MessageType = nameof(NotificationEvent);
    }

    public ENotificationType NotificationType { get; private set; }
    public string From { get; private set; }
    public string Body { get; private set; }
    public string To { get; private set; }
}
