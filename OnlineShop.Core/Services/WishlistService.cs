using OnlineShop.Core.Interfaces.Repository;
using OnlineShop.Core.Interfaces.Service;
using OnlineShop.Core.Model;

namespace OnlineShop.Core.Services;

public class WishlistService : IWishlistService
{
    private readonly IWishlistRepository _wishlistRepository;

    public WishlistService(IWishlistRepository wishlistRepository)
    {
        _wishlistRepository = wishlistRepository;
    }

    public Task<List<Wishlist>> GetAllWishlistsByUserIdAsync(string userId)
    {
        return _wishlistRepository.GetWishlistByUserIdAsync(userId);
    }
}