using API.External.Auth.Feature.Notification.Request;

namespace API.External.Auth.Feature.Notification.Service;

public interface ITwilioService
{
    Task TwilioAsync(TwilioRequest dto);
}
