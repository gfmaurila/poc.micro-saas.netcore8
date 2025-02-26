namespace API.External.Email.Model;

public class SendModel
{
    public int Id { get; set; }
    public AuthModel Auth { get; set; }
    public string To { get; set; }
    public ENotificationType Notification { get; set; }
    public string Body { get; set; }

    //[JsonIgnore]
    public DateTime DtSend { get; set; }
}


public class SendResponseModel
{
    public SendModel Request { get; set; }
    public DateTime DtSend { get; set; }
    public int Code { get; set; }
}
