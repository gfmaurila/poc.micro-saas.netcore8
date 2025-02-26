using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.Person.Domain;

public class PhoneEntity : BaseEntity, IAggregateRoot
{
    public Guid CustomerId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Type { get; set; } // Celular, Fixo, Comercial, etc.
    public string AreaCode { get; set; }
    public string Number { get; set; }
    public Guid PersonId { get; set; }
    public PersonEntity Person { get; set; }
}
