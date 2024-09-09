using Chayxana.Domain.Entities.Users;
using Chayxana.Domain.Enums;

namespace Chayxana.Domain.Entities.Branches;

public class Branch : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Status Status { get; set; }
    public ICollection<User> Users { get; set; }
}