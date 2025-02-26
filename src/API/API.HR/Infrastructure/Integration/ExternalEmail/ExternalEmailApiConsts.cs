namespace API.HR.Infrastructure.Integration.ExternalEmail;

public class ExternalEmailApiConsts
{
    public const string BaseUrl = "APIGateway:APIExternalEmail:UrlBase";
    public const string AccountSid = "APIGateway:APIExternalEmail:Authentication:AccountSid";
    public const string AuthToken = "APIGateway:APIExternalEmail:Authentication:AuthToken";
    public const string From = "APIGateway:APIExternalEmail:Authentication:From";


    public const string TIMEOUT = "APIGateway:TIMEOUT";
    public const string RETRYCOUNT = "APIGateway:RetryPolicy:RetryCount";
    public const string SleepDurationProvider = "APIGateway:RetryPolicy:SleepDurationProvider";
}
