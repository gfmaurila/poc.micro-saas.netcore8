using Common.External.Auth.Net8.Enumerado;
using Common.External.Auth.Net8.Events;

namespace API.External.Auth.Feature.Notification.Events;

public class NotificationTwilioEvent : Event
{
    public NotificationTwilioEvent(ENotificationType notificationType, string from, string body, string to)
    {
        NotificationType = notificationType;
        From = from;
        Body = body;
        To = to;
    }

    public int Id { get; private set; }
    public ENotificationType NotificationType { get; private set; }
    public string From { get; private set; }
    public string Body { get; private set; }
    public string To { get; private set; }
}
