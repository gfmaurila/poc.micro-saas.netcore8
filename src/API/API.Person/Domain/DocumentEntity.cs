using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.Person.Domain;

public class DocumentEntity : BaseEntity, IAggregateRoot
{
    public Guid CustomerId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Type { get; set; } // CPF, RG, CNPJ, etc.
    public string Number { get; set; }
    public DateTime IssueDate { get; set; }
    public string IssuingAuthority { get; set; }
    public string Country { get; set; }
    public Guid PersonId { get; set; }
    public PersonEntity Person { get; set; }
}
