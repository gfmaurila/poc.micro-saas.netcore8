namespace API.HR.Feature.External.ExternalEmail.Create.Model;

public class CreateEmailResponseModel
{
    public EmailRequestModel Request { get; set; }
    public DateTime DtSend { get; set; }
    public int Code { get; set; }
}



