namespace OnlineShop.Core.Dto.Auth;

public class ExchangeRefreshTokenRequest
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}