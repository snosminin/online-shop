namespace OnlineShop.Core.Dto;

public class WishlistDto
{
    public int Id { get; set; }

    public required UserDto User { get; set; }

    public required ProductDto Product { get; set; }
}