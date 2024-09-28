using Chayxana.Domain.Entities.Users;

namespace Chayxana.Domain.Entities.Rooms;

public class RoomFeedback : BaseEntity
{
    public long RoomId { get; set; }
    public Room Room { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}
