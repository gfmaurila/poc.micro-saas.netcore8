using API.External.Auth.Feature.Notification.Events;

namespace API.External.Auth.Feature.Notification.Producer;

public interface ITwilioProducer
{
    void PublishAsync(NotificationTwilioEvent evento);
}
