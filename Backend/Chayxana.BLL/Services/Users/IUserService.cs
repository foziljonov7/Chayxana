using AutoMapper;
using Chayxana.BLL.Commons;
using Chayxana.BLL.DTOs.UserDTOs;
using Chayxana.BLL.Helpers;
using Chayxana.BLL.Interfaces.Users;
using Chayxana.Domain.Entities.Users;
using Chayxana.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Chayxana.BLL.Services.Users;

public class UserService(
    IRepository<User> repository,
    IMapper mapper,
    IConfiguration configuration) : IUserService
{
    public async Task<UserDTO> RegisterAsync(RegisterDTO dto, CancellationToken cancellationToken = default)
    {
        var userResult = await repository.SelectAsync(x => x.PhoneNumber == dto.PhoneNumber);
        if (userResult is not null)
            throw new CustomException(404, "User already exists");

        var hasherResult = PasswordHelper.Hash(dto.Password);
        var mapped = mapper.Map<User>(dto);

        mapped.CreatedAt = DateTime.UtcNow.AddHours(5);
        mapped.Salt = hasherResult.salt;
        mapped.Password = hasherResult.hash;

        var result = await repository.AddAsync(mapped, cancellationToken);
        await repository.SaveAsync(cancellationToken);

        return mapper.Map<UserDTO>(result);
    }

    public async Task<bool> RemoveUserAsync(long id, CancellationToken cancellationToken = default)
    {
        var user = await repository.ExistsAsync(id, cancellationToken);
        if(user is false)
            throw new CustomException(404, "User does not exist");

        await repository.DeleteAsync(id, cancellationToken);
        return await repository.SaveAsync(cancellationToken);
    }

    public async Task<IEnumerable<UserDTO>> RetrieveAllUsersAsync(CancellationToken cancellationToken = default)
    {
        var userQuery = await repository.SelectAllAsync(null, null, cancellationToken);

        var users = await userQuery
            .AsNoTracking()
            .ToListAsync();

        if(users is null)
            throw new CustomException(404, "Users not found");

        return mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public async Task<UserDTO> RetrieveUserByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var user = await repository.SelectAsync(x => x.Id == id, null, cancellationToken);

        if(user is null)
            throw new CustomException(404, "User not found");

        return mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> UpdateUserAsync(long id, ModifyDTO dto, CancellationToken cancellationToken = default)
    {
        var user = await repository.SelectAsync(x => x.Id == id);
        if(user is null)
            throw new CustomException(404, "User does not exist");

        if(user is not null)
        {
            user.FirstName = string.IsNullOrEmpty(dto.FirstName)? user.FirstName : dto.FirstName;
            user.LastName = string.IsNullOrEmpty(dto.LastName)? user.LastName : dto.LastName;
            user.PhoneNumber = string.IsNullOrEmpty(dto.PhoneNumber)? user.PhoneNumber : dto.PhoneNumber;
            user.UpdatedAt = DateTime.UtcNow.AddHours(5);
            
            await repository.UpdateAsync(user, cancellationToken);
            await repository.SaveAsync(cancellationToken);
        }

        var result = mapper.Map(dto, user);

        return mapper.Map<UserDTO>(result);
    }
}
