using OnlineShop.Core.Model;

namespace OnlineShop.Core.Interfaces.Repository;

public interface IShoppingSessionRepository : IGenericRepository<ShoppingSession>
{
    Task<ShoppingSession?> GetShoppingSessionByUserIdAsync(string userId);
}