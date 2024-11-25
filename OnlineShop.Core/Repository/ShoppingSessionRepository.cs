using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Data;
using OnlineShop.Core.Interfaces.Repository;
using OnlineShop.Core.Model;

namespace OnlineShop.Core.Repository;

public class ShoppingSessionRepository : IShoppingSessionRepository
{

    private readonly OnlineShopDbContext _dbContext;

    public ShoppingSessionRepository(OnlineShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<ShoppingSession>> GetAllAsync()
    {
        return Task.FromResult(_dbContext.ShoppingSessions.ToList());
    }

    public Task<ShoppingSession?> GetByIdAsync(int id)
    {
        return _dbContext.ShoppingSessions.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<IReadOnlyList<ShoppingSession>> GetAllReadOnlyAsync()
    {
        return Task.FromResult<IReadOnlyList<ShoppingSession>>(_dbContext.ShoppingSessions.ToList().AsReadOnly());
    }

    public Task<ShoppingSession> InsertAsync(ShoppingSession entity)
    {
        return Task.FromResult(_dbContext.ShoppingSessions.AddAsync(entity).Result.Entity);
    }

    public Task<ShoppingSession> UpdateAsync(ShoppingSession entity)
    {
        return Task.FromResult(_dbContext.ShoppingSessions.Update(entity).Entity);
    }

    public Task<ShoppingSession> DeleteAsync(ShoppingSession entity)
    {
        return Task.FromResult(_dbContext.ShoppingSessions.Remove(entity).Entity);
    }

    public Task<ShoppingSession?> GetShoppingSessionByUserIdAsync(string userId)
    {
        return _dbContext.ShoppingSessions.Include(x => x.CartItems).ThenInclude(x => x.Product).Include(x => x.User)
            .Where(x => x.UserId == userId).SingleOrDefaultAsync();
    }
}