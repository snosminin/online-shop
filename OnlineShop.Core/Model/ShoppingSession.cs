namespace OnlineShop.Core.Model;

public class ShoppingSession : BaseEntity
{
    public required string UserId { get; set; }

    public required AppUser User { get; set; }
    public IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();
}