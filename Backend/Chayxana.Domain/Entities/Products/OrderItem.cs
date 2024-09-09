namespace Chayxana.Domain.Entities.Products;

public class OrderItem : BaseEntity
{
    public required long OrderId { get; set; }
    public Order Order { get; set; }
    public required long ProductId { get; set; }
    public Product Product { get; set; }
    public required int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double TotalAmount { get; set; }
}