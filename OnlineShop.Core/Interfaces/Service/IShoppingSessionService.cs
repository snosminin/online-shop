using OnlineShop.Core.Model;

namespace OnlineShop.Core.Interfaces.Service;

public interface IShoppingSessionService
{
    Task<ShoppingSession?> GetShoppingSessionByUserIdAsync(string userId);
}