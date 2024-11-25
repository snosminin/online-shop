namespace OnlineShop.Core.Dto;

public class ProductDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required ProductCategoryDto ProductCategory { get; set; }

    public required DiscountDto Discount { get; set; }

    public required string Description { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public required string Sku { get; set; }
}