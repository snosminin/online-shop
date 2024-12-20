namespace OnlineShop.Core.Dto;

public class CartItemDto
{
    public int Id { get; set; }
    public int ShoppingSessionId { get; set; }
    public int Quantity { get; set; }
    public required ProductDto Product { get; set; }
}