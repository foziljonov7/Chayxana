using Chayxana.BLL.DTOs.UserDTOs;

namespace Chayxana.BLL.Interfaces.Users;

public interface IUserRoleService
{
    Task<IEnumerable<UserRoleDTO>> RetrieveAllUserRolesAsync(CancellationToken cancellationToken = default);
    Task<bool> AssignRoleToUserAsync(long userId, long roleId, CancellationToken cancellationToken = default);
    Task<bool> RemoveRoleFromUserAsync(long userId, long roleId, CancellationToken cancellationToken = default);
    Task<IEnumerable<UserRoleDTO>> RetrieveRolesByUserIdAsync(long userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<UserRoleDTO>> RetrieveUsersByRoleIdAsync(long roleId, CancellationToken cancellationToken = default);
}