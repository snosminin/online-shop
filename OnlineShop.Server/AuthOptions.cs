using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace OnlineShop.Server;

public class AuthOptions
{
    public const string Issuer = "OnlineShopServer";
    public const string Audience = "OnlineShopClients";

    private const string Key =
        "1ChckIyvFrbuYYUwIeTPutHJcM7FZEIspWMUGk2kdCImOgcFhXLxcbD32Sqq0zVETrts9KUMuIDReo4xD06OLduD3uAZHFlKtIq6iXHrBDB2UV9wfKFuWGIXees2M6f8aeigsA8h7V7iyAoHX97pXKnrQp9Zg64yX3xnTeqeyo4bSbOEwlN0jiCjtvV5v1UTSpWRJuZSYwwXNlanJlxEA7e5iFbns42cPFDU0okXz4i31pQqYvoVKOk3osoUJTfw";

    public const int Lifetime = 1000000;

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}