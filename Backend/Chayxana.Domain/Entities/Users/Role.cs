namespace Chayxana.Domain.Entities.Users;

public class Role : BaseEntity
{
    public required string Name { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}