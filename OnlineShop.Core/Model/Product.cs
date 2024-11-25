namespace OnlineShop.Core.Model;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public int DiscountId { get; set; }
    public int ProductCategoryId { get; set; }
    public required string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public required string Sku { get; set; }

    public required Discount Discount { get; set; }
    public required ProductCategory ProductCategory { get; set; }
    public ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    //public IEnumerable<ProductAttachment> ProductAttachments { get; set; }
}