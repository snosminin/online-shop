using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Data;
using OnlineShop.Core.Interfaces.Repository;
using OnlineShop.Core.Model;

namespace OnlineShop.Core.Repository;

public class WishlistRepository : IWishlistRepository
{

    private readonly OnlineShopDbContext _dbContext;

    public WishlistRepository(OnlineShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Wishlist>> GetWishlistByUserIdAsync(string userId)
    {
        return Task.FromResult(_dbContext.Wishlists.Include(x => x.Product).Where(x => x.UserId == userId).ToList());
    }

    public Task<List<Wishlist>> GetAllAsync()
    {
        return Task.FromResult(_dbContext.Wishlists.ToList());
    }

    public Task<Wishlist?> GetByIdAsync(int id)
    {
        return _dbContext.Wishlists.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<IReadOnlyList<Wishlist>> GetAllReadOnlyAsync()
    {
        return Task.FromResult<IReadOnlyList<Wishlist>>(_dbContext.Wishlists.ToList().AsReadOnly());
    }

    public Task<Wishlist> InsertAsync(Wishlist entity)
    {
        return Task.FromResult(_dbContext.Wishlists.AddAsync(entity).Result.Entity);
    }

    public Task<Wishlist> UpdateAsync(Wishlist entity)
    {
        return Task.FromResult(_dbContext.Wishlists.Update(entity).Entity);
    }

    public Task<Wishlist> DeleteAsync(Wishlist entity)
    {
        return Task.FromResult(_dbContext.Wishlists.Remove(entity).Entity);
    }
}