using Common.External.Auth.Net8.Model;

namespace Common.External.Auth.Net8.Interface;

public interface INotificationHandle
{
    bool IsNotification();
    List<Notification> GetNotification();
    void Handle(Notification notification);
}
