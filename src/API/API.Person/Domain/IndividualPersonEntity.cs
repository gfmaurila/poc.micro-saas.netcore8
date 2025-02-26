using Common.Core._08.Domain.Enumerado;

namespace API.Person.Domain;

public class IndividualPersonEntity : PersonEntity
{
    public Guid CustomerId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string CPF { get; set; }
    public DateTime BirthDate { get; set; }
    public EGender Gender { get; set; } = EGender.None;
    public string? MotherName { get; set; }
    public string? FatherName { get; set; }
}
