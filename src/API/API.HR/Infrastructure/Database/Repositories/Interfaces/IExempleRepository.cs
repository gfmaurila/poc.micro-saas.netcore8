using API.Exemple1.Core._08.Feature.Exemple.Queries.GetPaginate;
using API.HR.Feature.Domain.Exemple;
using API.HR.Feature.Domain.Exemple.Models;
using Common.Core._08.Domain.Interface;
using Common.Core._08.Domain.ValueObjects;

namespace API.HR.Infrastructure.Database.Repositories.Interfaces;

public interface IExempleRepository : IBaseRepository<ExempleEntity>
{
    Task<List<ExempleQueryModel>> GetAllAsync();
    Task<List<ExempleQueryModel>> GetPaginatedItemsAsync(GetPaginateExempleQuery query);
    Task<int> GetTotalCountAsync(GetPaginateExempleQuery query);
    Task<bool> ExistsByEmailAsync(Email email);
    Task<ExempleQueryModel> GetByIdAsync(Guid id);
}
