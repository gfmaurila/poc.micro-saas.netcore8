using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.Person.Domain;

public class EmailEntity : BaseEntity, IAggregateRoot
{
    public Guid CustomerId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Address { get; set; }
    public string Type { get; set; } // Pessoal, Comercial, etc.
    public Guid PersonId { get; set; }
    public PersonEntity Person { get; set; }
}
