namespace API.Customer.Feature.External.ExternalEmail.Get.Model;

public class EmailQueryModel
{
    public int Id { get; set; }
    public AuthEmailQueryModel Auth { get; set; }
    public string To { get; set; }
    public int Notification { get; set; }
    public string Body { get; set; }
    public DateTime DtSend { get; set; }
}