namespace Chayxana.Domain.Entities.Rooms;

public class Booking : BaseEntity
{
    public required long RoomId { get; set; }
    public Room Room { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime BookingTime { get; set; }
}