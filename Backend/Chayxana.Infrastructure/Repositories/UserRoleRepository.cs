
using Chayxana.DAL.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Chayxana.Infrastructure.Repositories;

public class UserRoleRepository(
    AppDbContext context) : IUserRoleRepository
{
    public async Task<bool> DeleteAsync(long userId, long roleId, CancellationToken cancellationToken = default)
    {
        var userRole = await context.UserRoles
            .FirstOrDefaultAsync(u => u.UserId == userId && u.RoleId == roleId, cancellationToken);

        context.UserRoles.Remove(userRole);
        return true;
    }

    public async Task<bool> SaveAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
}
