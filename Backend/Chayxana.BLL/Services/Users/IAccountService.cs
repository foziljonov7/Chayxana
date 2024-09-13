using Chayxana.BLL.DTOs.UserDTOs;
using Chayxana.BLL.Interfaces.Users;
using Chayxana.Domain.Entities.Users;
using Chayxana.Infrastructure.Repositories;

namespace Chayxana.BLL.Services.Users;

public class AccountService(
    IRepository<User> repository,
    IAuthService service) : IAccountService
{
    public Task<string> LoginAsync(LoginDTO user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
