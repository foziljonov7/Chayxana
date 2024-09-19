using AutoMapper;
using Chayxana.BLL.Commons;
using Chayxana.BLL.DTOs.UserDTOs;
using Chayxana.BLL.Interfaces.Users;
using Chayxana.Domain.Entities.Users;
using Chayxana.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chayxana.BLL.Services.Users;

public class RoleService(
    IRepository<Role> repository,
    IMapper mapper) : IRoleService
{
    public async Task<RoleDTO> AddRoleAsync(string name, CancellationToken cancellationToken = default)
    {
        var role = mapper.Map<Role>(new RoleDTO { Name = name });
        await repository.AddAsync(role, cancellationToken);
        await repository.SaveAsync(cancellationToken);

        return mapper.Map<RoleDTO>(role);
    }

    public async Task<bool> RemoveRoleAsync(long id, CancellationToken cancellationToken = default)
    {
        var role = await repository.ExistsAsync(id, cancellationToken);
        if(!role)
            throw new CustomException(404, "Role not found");

        await repository.DeleteAsync(id, cancellationToken);
        return await repository.SaveAsync(cancellationToken);
    }

    public async Task<IEnumerable<RoleDTO>> RetrieveAllRolesAsync(CancellationToken cancellationToken = default)
    {
        var roleQuery = await repository.SelectAllAsync(null, null, cancellationToken);

        var roles = await roleQuery
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        if(roles is null)
            throw new CustomException(404, "No roles found");

        return mapper.Map<IEnumerable<RoleDTO>>(roles);
    }
}
