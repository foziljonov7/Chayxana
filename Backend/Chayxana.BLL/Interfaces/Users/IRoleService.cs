using Chayxana.BLL.DTOs.UserDTOs;

namespace Chayxana.BLL.Interfaces.Users;

public interface IRoleService
{
    Task<IEnumerable<RoleDTO>> RetrieveAllRolesAsync(CancellationToken cancellationToken = default);
    Task<RoleDTO> AddRoleAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> RemoveRoleAsync(long id, CancellationToken cancellationToken = default);
}