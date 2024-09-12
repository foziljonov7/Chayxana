using Chayxana.BLL.DTOs.UserDTOs;

namespace Chayxana.BLL.Interfaces.Users;
public interface IAccountService
{
    Task<string> LoginAsync(LoginDTO user, CancellationToken cancellationToken = default);
}