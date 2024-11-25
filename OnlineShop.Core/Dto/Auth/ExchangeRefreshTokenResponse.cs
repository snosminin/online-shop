namespace OnlineShop.Core.Dto.Auth;

public class ExchangeRefreshTokenResponse
{
    public ExchangeRefreshTokenResponse(AccessToken accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public AccessToken AccessToken { get; }
    public string RefreshToken { get; }
}