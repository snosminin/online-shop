namespace OnlineShop.Core.Model;

public class Discount : BaseEntity
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public double Value { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}