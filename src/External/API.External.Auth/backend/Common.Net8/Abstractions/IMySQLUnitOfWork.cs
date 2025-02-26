namespace Common.External.Auth.Net8.Abstractions;

public interface IMySQLUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
}
