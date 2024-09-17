using AutoMapper;
using Chayxana.BLL.Commons;
using Chayxana.BLL.Helpers;
using Chayxana.BLL.Interfaces.Users;
using Chayxana.Domain.Entities.Users;
using Chayxana.Infrastructure.Repositories;

namespace Chayxana.BLL.Services.Users;

public class UserPasswordService(
    IRepository<User> repository,
    IMapper mapper) : IUserPasswordService
{
    public async Task<bool> ChangePasswordAsync(long id, string currentPassword, string newPassword, CancellationToken cancellationToken = default)
    {
        var user = await repository.SelectAsync(x => x.Id == id);

        if(user is null)
            throw new CustomException(404, "User not found");

        if(!PasswordHelper.Verify(currentPassword, user.Salt, user.Password))
            throw new CustomException(401, "User current password is wrong!");

        var hasherResult = PasswordHelper.Hash(newPassword);
        user.Password = hasherResult.hash;
        user.Salt = hasherResult.salt;

        var result = mapper.Map<User>(user);
        await repository.UpdateAsync(result, cancellationToken);
        return await repository.SaveAsync(cancellationToken);
    }

    public async Task<bool> VerifyPasswordAsync(long id, string password, CancellationToken cancellationToken = default)
    {
        var user = await repository.SelectAsync(x => x.Id == id);

        if(user is null) 
            throw new CustomException(404, "User not found");

        if(!PasswordHelper.Verify(password, user.Salt, user.Password))
            return false;

        return true;
    }
}
