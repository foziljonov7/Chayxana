namespace Chayxana.Infrastructure.Repositories;

public interface IUserRoleRepository
{
    Task<bool> DeleteAsync(long userId, long roleId, CancellationToken cancellationToken = default);
    Task<bool> SaveAsync(CancellationToken cancellationToken = default);
}