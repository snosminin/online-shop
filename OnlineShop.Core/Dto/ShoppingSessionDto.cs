namespace OnlineShop.Core.Dto;

public class ShoppingSessionDto
{
    public int Id { get; set; }
    public required UserDto User { get; set; }
    public required List<CartItemDto> CartItems { get; set; }
}