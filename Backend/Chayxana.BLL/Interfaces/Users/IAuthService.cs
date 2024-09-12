using Chayxana.Domain.Entities.Users;

namespace Chayxana.BLL.Interfaces.Users;

public interface IAuthService
{
    string GenerateToken(User user);
}