namespace OnlineShop.Core.Model;

public class ProductCategory : BaseEntity
{
    public required string Name { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}