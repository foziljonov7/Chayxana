namespace Chayxana.Domain.Entities.Products;

public class Order : BaseEntity
{
    public required long RoomId { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }
    public ICollection<OrderItem> Items { get; set; }
}