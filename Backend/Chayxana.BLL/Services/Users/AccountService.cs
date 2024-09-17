using Chayxana.BLL.Commons;
using Chayxana.BLL.DTOs.UserDTOs;
using Chayxana.BLL.Helpers;
using Chayxana.BLL.Interfaces.Users;
using Chayxana.Domain.Entities.Users;
using Chayxana.Infrastructure.Repositories;

namespace Chayxana.BLL.Services.Users;

public class AccountService(
    IRepository<User> repository,
    IAuthService service) : IAccountService
{
    public async Task<string> LoginAsync(LoginDTO login, CancellationToken cancellationToken = default)
    {
        var user = await repository.SelectAsync(x => x.PhoneNumber == login.PhoneNumber);
        if(user is null)
            throw new CustomException(404, "PhoneNumber or Password wrong!");
        
        var hasherResult = PasswordHelper.Verify(login.Password, user.Salt, user.Password);
        if(!hasherResult)
            throw new CustomException(401, "PhoneNumber or Password wrong!");

        return service.GenerateToken(user);
    }
}
