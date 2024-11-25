namespace OnlineShop.Core.Model;

public class CartItem : BaseEntity
{
    public int ShoppingSessionId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public required ShoppingSession ShoppingSession { get; set; }
    public required Product Product { get; set; }
}