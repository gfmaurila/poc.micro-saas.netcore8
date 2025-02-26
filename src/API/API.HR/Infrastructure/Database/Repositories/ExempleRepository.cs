using API.Exemple1.Core._08.Feature.Exemple.Queries.GetPaginate;
using API.HR.Feature.Domain.Exemple;
using API.HR.Feature.Domain.Exemple.Models;
using API.HR.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace API.HR.Infrastructure.Database.Repositories;

/// <summary>
/// Repository implementation for managing <see cref="ExempleEntity"/> data.
/// Provides methods for retrieving, querying, and validating Exemple entities.
/// </summary>
public class ExempleRepository : BaseRepository<ExempleEntity>, IExempleRepository
{
    private readonly CustomerAppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleRepository"/> class.
    /// </summary>
    /// <param name="context">Database context for accessing Exemple data.</param>
    public ExempleRepository(CustomerAppDbContext context) : base(context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all Exemple entities from the database.
    /// </summary>
    /// <returns>A list of <see cref="ExempleQueryModel"/> containing all Exemple entities.</returns>
    public async Task<List<ExempleQueryModel>> GetAllAsync()
        => MapperModelToEntity(await _context.Exemple.AsNoTracking().ToListAsync());

    /// <summary>
    /// Retrieves paginated Exemple entities based on filter criteria.
    /// </summary>
    /// <param name="query">Query containing pagination and filter parameters.</param>
    /// <returns>A paginated list of <see cref="ExempleQueryModel"/>.</returns>
    public async Task<List<ExempleQueryModel>> GetPaginatedItemsAsync(GetPaginateExempleQuery query)
    {
        return await _context.Exemple.AsNoTracking()
            .Where(e => string.IsNullOrEmpty(query.FiltroFirstName) || e.FirstName.Contains(query.FiltroFirstName))
            .Skip(query.CalculateRecordsToSkip()) // Pagination offset
            .Take(query.PageSize) // Page size limit
            .Select(e => new ExempleQueryModel
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email.Address,
                Phone = e.Phone.Phone,
                Gender = e.Gender,
                Notification = e.Notification,
                Role = e.Role
            })
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves the total count of Exemple entities based on filter criteria.
    /// </summary>
    /// <param name="query">Query containing filter parameters.</param>
    /// <returns>The total count of matching Exemple entities.</returns>
    public async Task<int> GetTotalCountAsync(GetPaginateExempleQuery query)
    {
        return await _context.Exemple.AsNoTracking()
            .CountAsync(e => string.IsNullOrEmpty(query.FiltroFirstName) || e.FirstName.Contains(query.FiltroFirstName));
    }

    /// <summary>
    /// Checks if an Exemple entity exists based on the provided email.
    /// </summary>
    /// <param name="email">The email address to check for existence.</param>
    /// <returns><c>true</c> if an entity exists with the given email; otherwise, <c>false</c>.</returns>
    public async Task<bool> ExistsByEmailAsync(Email email)
        => await _context.Exemple.AsNoTracking().AnyAsync(entity => entity.Email.Address == email.Address);

    /// <summary>
    /// Retrieves an Exemple entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the Exemple entity.</param>
    /// <returns>An <see cref="ExempleQueryModel"/> if found; otherwise, <c>null</c>.</returns>
    public async Task<ExempleQueryModel> GetByIdAsync(Guid id)
    {
        var entity = await _context.Exemple.AsNoTracking()
                                   .Where(u => u.Id == id)
                                   .FirstOrDefaultAsync();
        return entity is not null ? MapperModelToEntity(entity) : null;
    }

    #region Private Methods

    /// <summary>
    /// Maps a list of <see cref="ExempleEntity"/> to a list of <see cref="ExempleQueryModel"/>.
    /// </summary>
    /// <param name="entity">The list of Exemple entities to be mapped.</param>
    /// <returns>A list of mapped <see cref="ExempleQueryModel"/>.</returns>
    private List<ExempleQueryModel> MapperModelToEntity(List<ExempleEntity> entity)
    {
        return entity.Select(entityItem => new ExempleQueryModel
        {
            Id = entityItem.Id,
            FirstName = entityItem.FirstName,
            LastName = entityItem.LastName,
            Gender = entityItem.Gender,
            Email = entityItem.Email.Address,
            Phone = entityItem.Phone.Phone,
            Role = entityItem.Role
        }).ToList();
    }

    /// <summary>
    /// Maps a single <see cref="ExempleEntity"/> to an <see cref="ExempleQueryModel"/>.
    /// </summary>
    /// <param name="entity">The Exemple entity to be mapped.</param>
    /// <returns>A mapped <see cref="ExempleQueryModel"/>.</returns>
    private ExempleQueryModel MapperModelToEntity(ExempleEntity entity)
    {
        return new ExempleQueryModel
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Gender = entity.Gender,
            Email = entity.Email.Address,
            Phone = entity.Phone.Phone,
            Role = entity.Role
        };
    }

    #endregion
}
