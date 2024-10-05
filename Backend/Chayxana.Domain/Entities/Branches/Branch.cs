using Chayxana.Domain.Entities.Rooms;
using Chayxana.Domain.Entities.Users;
using Chayxana.Domain.Enums;

namespace Chayxana.Domain.Entities.Branches;

public class Branch : BaseEntity
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
    public string Salt { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Status Status { get; set; }
    public BranchType Type { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<Room> Rooms { get; set; }
    public ICollection<BranchFeedback> Feedbacks { get; set; }
}