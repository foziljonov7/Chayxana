using Chayxana.Domain.Entities.Branches;
using Chayxana.Domain.Enums;

namespace Chayxana.Domain.Entities.Rooms;

public class Room : BaseEntity
{
    public required long BranchId { get; set; }
    public Branch Branch { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Capacity { get; set; }
    public ICollection<Booking> Bookings { get; set; }
    public ICollection<RoomFeedback> Feedbacks { get; set; }
    public Status Status { get; set; }
}