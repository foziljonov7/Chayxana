namespace Chayxana.BLL.Interfaces.Users;

public interface IUserPasswordService
{
    Task<bool> ChangePasswordAsync(long id, string currentPassword, string newPassword, CancellationToken cancellationToken = default);
    Task<bool> VerifyPasswordAsync(long id, string password, CancellationToken cancellationToken = default);
}