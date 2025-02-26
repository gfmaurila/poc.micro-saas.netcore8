using Common.Core._08.Interface;

namespace API.Exemple.Core._08.Infrastructure.Database;

public class UnitOfWork(ExempleAppDbContext dbContext) : IUnitOfWork
{
    private readonly ExempleAppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose() => _dbContext.Dispose();
}
