using Common.Core._08.Interface;

namespace API.Freelancer.Infrastructure.Database;

public class UnitOfWork(CustomerAppDbContext dbContext) : IUnitOfWork
{
    private readonly CustomerAppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose() => _dbContext.Dispose();
}
