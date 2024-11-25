using OnlineShop.Core.Interfaces.Repository;
using OnlineShop.Core.Interfaces.Service;
using OnlineShop.Core.Model;

namespace OnlineShop.Core.Services;

public class ShoppingSessionService : IShoppingSessionService
{
    private readonly IShoppingSessionRepository _shoppingSessionRepository;

    public ShoppingSessionService(IShoppingSessionRepository shoppingSessionRepository)
    {
        _shoppingSessionRepository = shoppingSessionRepository;
    }

    public Task<ShoppingSession?> GetShoppingSessionByUserIdAsync(string userId)
    {
        return _shoppingSessionRepository.GetShoppingSessionByUserIdAsync(userId);
    }
}