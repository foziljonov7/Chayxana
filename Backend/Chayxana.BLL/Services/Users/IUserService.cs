using Chayxana.BLL.DTOs.UserDTOs;
using Chayxana.BLL.Interfaces.Users;

namespace Chayxana.BLL.Services.Users;

public class UserService : IUserService
{
    public Task<UserDTO> RegisterAsync(RegisterDTO user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveUserAsync(long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDTO>> RetrieveAllUsersAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> RetrieveUserByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> UpdateUserAsync(long id, ModifyDTO user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
