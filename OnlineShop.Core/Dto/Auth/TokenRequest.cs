namespace OnlineShop.Core.Dto.Auth;

public class TokenRequest
{
    public required string Username { get; set; }
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
}