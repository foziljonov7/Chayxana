using AutoMapper;
using Chayxana.BLL.Commons;
using Chayxana.BLL.DTOs.UserDTOs;
using Chayxana.BLL.Interfaces.Users;
using Chayxana.Domain.Entities.Users;
using Chayxana.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chayxana.BLL.Services.Users;

public class UserRoleService(
    IRepository<UserRole> repository,
    IUserRoleRepository userRoleRepository,
    IMapper mapper) : IUserRoleService
{
    public async Task<bool> AssignRoleToUserAsync(long userId, long roleId, CancellationToken cancellationToken = default)
    {
        var userRole = mapper.Map<UserRole>(new UserRoleDTO {UserId = userId, RoleId = roleId});
        await repository.AddAsync(userRole, cancellationToken);
        return await repository.SaveAsync(cancellationToken);
    }

    public async Task<bool> RemoveRoleFromUserAsync(long userId, long roleId, CancellationToken cancellationToken = default)
    {
        var userRoles = await repository.SelectAllAsync(null, null, cancellationToken);

        var userRole = userRoles.FirstOrDefault(x => x.UserId == userId && x.RoleId == roleId);

        if(userRole is null)
            throw new CustomException(404, "User role not found");

        await userRoleRepository.DeleteAsync(userId, roleId, cancellationToken);
        return await userRoleRepository.SaveAsync(cancellationToken);
    }

    public async Task<IEnumerable<UserRoleDTO>> RetrieveAllUserRolesAsync(CancellationToken cancellationToken = default)
    {
        var userRoleQuery = await repository.SelectAllAsync(null, null, cancellationToken);

        var userRoles = await userRoleQuery
            .AsNoTracking()
            .ToListAsync();

        if(userRoles is null)
            throw new CustomException(404, "UserRoles not found");

        return mapper.Map<IEnumerable<UserRoleDTO>>(userRoles);
    }

    public async Task<IEnumerable<UserRoleDTO>> RetrieveRolesByUserIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        var userRoleQuery = await repository.SelectAllAsync(null, null, cancellationToken);

        var userRoles = await userRoleQuery
           .Where(x => x.UserId == userId)
            .AsNoTracking()
            .ToListAsync();

        if(userRoles is null)
            throw new CustomException(404, "UserRole not found");

        return mapper.Map<IEnumerable<UserRoleDTO>>(userRoles);
    }

    public async Task<IEnumerable<UserRoleDTO>> RetrieveUsersByRoleIdAsync(long roleId, CancellationToken cancellationToken = default)
    {
        var userRoleQuery = await repository.SelectAllAsync(null, null, cancellationToken);

        var userRoles = await userRoleQuery
            .Where(x => x.RoleId == roleId)
            .AsNoTracking()
            .ToListAsync();

        if(userRoles is null)
            throw new CustomException(404, "User not found");

        return mapper.Map<IEnumerable<UserRoleDTO>>(userRoles);
    }
}
