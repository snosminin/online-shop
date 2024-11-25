using OnlineShop.Core.Model;

namespace OnlineShop.Core.Interfaces.Service;

public interface IWishlistService
{
    Task<List<Wishlist>> GetAllWishlistsByUserIdAsync(string userId);
}