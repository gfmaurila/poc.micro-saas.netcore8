using Common.External.Auth.Net8.Enumerado;

namespace API.External.Auth.Feature.Notification.Request;

public class TwilioRequest
{
    public AuthDTO Auth { get; set; }
    public string To { get; set; }
    public ENotificationType Notification { get; set; }
    public string Body { get; set; }
}