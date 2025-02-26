namespace API.Freelancer.Infrastructure.Integration.ExternalEmail.Model;

public class CreateSendRequest
{
    public int Id { get; set; }
    public ExternalEmailAuth Auth { get; set; }
    public string To { get; set; }
    public int Notification { get; set; }
    public string Body { get; set; }
}

public class ExternalEmailAuth
{
    public string AccountSid { get; set; }
    public string AuthToken { get; set; }
    public string From { get; set; }
}

public class CreateSendResponse
{
    public CreateSendRequest Request { get; set; }
    public DateTime DtSend { get; set; }
    public int Code { get; set; }
}


public class ListSendResponse
{
    public int Id { get; set; }
    public ExternalEmailAuth Auth { get; set; }
    public string To { get; set; }
    public int Notification { get; set; }
    public string Body { get; set; }
    public DateTime DtSend { get; set; }
}
