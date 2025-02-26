using Common.Core._08.Domain.Enumerado;

namespace API.Exemple1.Core._08.Feature.Notification.Messaging.Request;

public class NotificationRequest
{
    public AuthNotification Auth { get; set; }
    public string To { get; set; }
    public ENotificationType Notification { get; set; }
    public string Body { get; set; }
}
