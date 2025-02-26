namespace Common.External.Auth.Net8.Response;

public class ErrorDetail
{
    public string Message { get; set; }

    public ErrorDetail(string message)
    {
        Message = message;
    }
}
