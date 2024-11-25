namespace OnlineShop.Core.Model;

public class Wishlist : BaseEntity
{
    public required string UserId { get; set; }

    public int ProductId { get; set; }

    public required AppUser User { get; set; }

    public required Product Product { get; set; }
}