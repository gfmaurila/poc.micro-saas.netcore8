namespace API.HR.Infrastructure.Integration;

public class ApiConsts
{
    public const string BaseUrl = "APIExternalEmail:BaseUrl";
    public const string AccountSid = "APIExternalEmail:Auth:AccountSid";
    public const string AuthToken = "APIExternalEmail:Auth:AuthToken";
    public const string From = "APIExternalEmail:Auth:From";
    public const string TIMEOUT = "APIExternalEmail:TIMEOUT";
    public const string RETRYCOUNT = "APIExternalEmail:RetryPolicy:RetryCount";
    public const string SleepDurationProvider = "APIExternalEmail:RetryPolicy:SleepDurationProvider";
}
