namespace Chayxana.Domain.Entities.Users;

public class UserRole
{
    public required long UserId { get; set; }
    public User? User { get; set; }
    public required long RoleId { get; set; }
    public Role? Role { get; set; }
}