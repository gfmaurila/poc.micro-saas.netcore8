using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Freelancer.Infrastructure.Database.Repositories;

/// <summary>
/// Provides a generic repository implementation for data access operations.
/// </summary>
/// <typeparam name="T">The entity type that extends <see cref="BaseEntity"/>.</typeparam>
public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly CustomerAppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
    /// </summary>
    /// <param name="context">The database context instance.</param>
    public BaseRepository(CustomerAppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new entity record in the database.
    /// </summary>
    /// <param name="obj">The entity object to be created.</param>
    /// <returns>The created entity.</returns>
    public virtual async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    /// <summary>
    /// Updates an existing entity record in the database.
    /// </summary>
    /// <param name="obj">The entity object to be updated.</param>
    /// <returns>The updated entity.</returns>
    public virtual async Task<T> Update(T obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return obj;
    }

    /// <summary>
    /// Removes an entity record from the database.
    /// </summary>
    /// <param name="obj">The entity object to be removed.</param>
    public virtual async Task Remove(T obj)
    {
        _context.Remove(obj);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    public virtual async Task<T> Get(Guid id)
    {
        var obj = await _context.Set<T>()
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .ToListAsync();

        return obj.FirstOrDefault();
    }

    /// <summary>
    /// Retrieves all entity records from the database.
    /// </summary>
    /// <returns>A list of all entities.</returns>
    public virtual async Task<List<T>> Get()
    {
        return await _context.Set<T>()
                             .AsNoTracking()
                             .ToListAsync();
    }
}
