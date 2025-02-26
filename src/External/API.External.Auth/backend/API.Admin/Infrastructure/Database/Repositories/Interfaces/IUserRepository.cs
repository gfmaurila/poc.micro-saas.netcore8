using API.External.Auth.Domain.User;
using API.External.Auth.Feature.Users.GetUser;
using Common.External.Auth.Net8.Abstractions;
using Common.External.Auth.Net8.ValueObjects;

namespace API.External.Auth.Infrastructure.Database.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task<bool> ExistsByEmailAsync(Email email);
    Task<bool> ExistsByEmailAsync(Email email, Guid currentId);
    Task<List<UserQueryModel>> GetAllAsync();
    Task<UserQueryModel> GetByIdAsync(Guid id);
    Task<UserEntity> GetAuthByEmailPassword(string email, string passwordHash);
    Task<UserEntity> GetByEmailAsync(string email);
}

