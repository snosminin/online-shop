namespace OnlineShop.Core.Dto.Auth;

public class LoginResponse(string token, string username)
{
    public string Token { get;} = token;
    public string Username { get; } = username;
}