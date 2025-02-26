using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.Person.Domain;

public class PersonEntity : BaseEntity, IAggregateRoot
{
    public Guid CustomerId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Type { get; set; } // "F" para Pessoa Física, "J" para Pessoa Jurídica
    public List<DocumentEntity> Documents { get; set; } = new();
    public List<AddressEntity> Addresses { get; set; } = new();
    public List<PhoneEntity> Phones { get; set; } = new();
    public List<EmailEntity> Emails { get; set; } = new();
}
