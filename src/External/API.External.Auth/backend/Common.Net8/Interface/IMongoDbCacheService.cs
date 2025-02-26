using Common.External.Auth.Net8.Abstractions;

namespace Common.External.Auth.Net8.Interface;

public interface IMongoDbCacheService
{
    Task<IEntityMongoDb> CreateAsync(IEntityMongoDb entity, TimeSpan? ttl = null);
    Task<IEntityMongoDb> CreateAsync(IEntityMongoDb entity);
    Task<IEntityMongoDb> UpdateAsync(IEntityMongoDb entity);
    Task<bool> DeleteAsync(string id);
    Task<IEntityMongoDb> GetByIdAsync(string id);
    Task<IEnumerable<IEntityMongoDb>> GetAllAsync();
}
