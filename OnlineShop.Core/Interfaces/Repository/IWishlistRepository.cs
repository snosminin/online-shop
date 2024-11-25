using OnlineShop.Core.Model;

namespace OnlineShop.Core.Interfaces.Repository;

public interface IWishlistRepository : IGenericRepository<Wishlist>
{
    Task<List<Wishlist>> GetWishlistByUserIdAsync(string userId);
}