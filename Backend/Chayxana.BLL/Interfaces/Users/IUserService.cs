using Chayxana.BLL.DTOs.UserDTOs;

namespace Chayxana.BLL.Interfaces.Users;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> RetrieveAllUsersAsync(CancellationToken cancellationToken = default);
    Task<UserDTO> RetrieveUserByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<UserDTO> RegisterAsync(RegisterDTO dto, CancellationToken cancellationToken = default);
    Task<UserDTO> UpdateUserAsync(long id, ModifyDTO dto, CancellationToken cancellationToken = default);
    Task<bool> RemoveUserAsync(long id, CancellationToken cancellationToken = default);
}