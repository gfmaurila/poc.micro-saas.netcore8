using Common.External.Auth.Net8.Abstractions;

namespace API.External.Auth.Domain;

public abstract class BaseQueryModel : IQueryModel<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
