namespace API.Person.Domain;

public class LegalEntity : PersonEntity
{
    public Guid CustomerId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string CNPJ { get; set; }
    public string TradeName { get; set; }
    public DateTime OpeningDate { get; set; }
    public string? StateRegistration { get; set; }
    public string? MunicipalRegistration { get; set; }
    public List<string> Partners { get; set; } = new();
}
