using Chayxana.Domain.Entities.Rooms;

namespace Chayxana.Domain.Entities.Products;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }
    public Booking Booking { get; set; }
    public long BookingId { get; set; }
    public ICollection<OrderItem> Items { get; set; }
}