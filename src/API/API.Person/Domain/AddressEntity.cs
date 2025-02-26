using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.Person.Domain;

public class AddressEntity : BaseEntity, IAggregateRoot
{
    public Guid CustomerId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Type { get; set; } // Residencial, Comercial, etc.
    public string Street { get; set; }
    public string Number { get; set; }
    public string? Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public Guid PersonId { get; set; }
    public PersonEntity Person { get; set; }
}
