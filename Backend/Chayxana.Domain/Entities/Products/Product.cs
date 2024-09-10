namespace Chayxana.Domain.Entities.Products;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required double Price { get; set; }
    public string Description { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}