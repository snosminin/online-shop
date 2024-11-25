namespace OnlineShop.Core.Dto.Auth;

public class LoginResponse
{
    public required string Token { get; set; }
    public required string Username { get; set; }
}