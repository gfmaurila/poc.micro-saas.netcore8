namespace API.Exemple.Core._08.Feature.External.ExternalEmail.Create.Model;

public class EmailRequestModel
{
    public int Id { get; set; }
    public AuthEmailModel Auth { get; set; }
    public string To { get; set; }
    public int Notification { get; set; }
    public string Body { get; set; }
}
