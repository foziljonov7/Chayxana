using Chayxana.Domain.Enums;

namespace Chayxana.Domain.Entities.Users;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
    public string Salt { get; set; }
    public Status Status { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}