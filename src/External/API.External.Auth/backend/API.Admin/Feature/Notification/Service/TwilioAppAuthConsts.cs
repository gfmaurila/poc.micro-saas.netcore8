namespace API.External.Auth.Feature.Notification.Service;

public class TwilioAppAuthConsts
{
    public const string URL_CODE = "TWILIO:URL:URL_CODE";

    public const string AccountSid = "TWILIO:Auth:AccountSid";
    public const string AuthToken = "TWILIO:Auth:AuthToken";
    public const string From = "TWILIO:Auth:From";

    public const string TIMEOUT = "TWILIO:TIMEOUT";
    public const string RETRYCOUNT = "TWILIO:RetryPolicy:RetryCount";
    public const string SleepDurationProvider = "TWILIO:RetryPolicy:SleepDurationProvider";
}
