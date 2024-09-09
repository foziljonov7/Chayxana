using Chayxana.Domain.Entities.Branches;
using Chayxana.Domain.Enums;

namespace Chayxana.Domain.Entities.Rooms;

public class Room : BaseEntity
{
    public long BranchId { get; set; }
    public Branch Branch { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
}