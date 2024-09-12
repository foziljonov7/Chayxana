using Chayxana.BLL.DTOs.UserDTOs;

namespace Chayxana.BLL.Interfaces.Users;

public interface IUserRoleService
{
    Task<IEnumerable<UserRoleDTO>> RetrieveAllUserRolesAsync(CancellationToken cancellationToken = default);
    Task<UserRoleDTO> RetrieveUserRoleByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<bool> AssignRoleToUserAsync(long userId, long roleId, CancellationToken cancellationToken = default);
    Task<bool> RemoveRoleFromUserAsync(long userId, long roleId, CancellationToken cancellationToken = default);
    Task<IEnumerable<RoleDTO>> RetrieveRolesByUserIdAsync(long userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<UserDTO>> RetrieveUsersByRoleIdAsync(long roleId, CancellationToken cancellationToken = default);
}