using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Interfaces.Repository;
using OnlineShop.Core.Model;
using OnlineShop.Infrastructure.Data;

namespace OnlineShop.Infrastructure.Repository;

public class ProductRepository : IProductRepository
{

    private readonly OnlineShopDbContext _dbContext;

    public ProductRepository(OnlineShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Product>> GetAllAsync()
    {
        return Task.FromResult(_dbContext.Products.Include(x => x.Discount)
            .Include(x => x.ProductCategory).ToList());
    }

    public Task<List<Product>> GetByProductCategoryIdAsync(int categoryId)
    {
        return Task.FromResult(_dbContext.Products.Include(x => x.Discount)
            .Include(x => x.ProductCategory).Where(x => x.ProductCategoryId == categoryId).ToList());
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        return _dbContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<IReadOnlyList<Product>> GetAllReadOnlyAsync()
    {
        return Task.FromResult<IReadOnlyList<Product>>(_dbContext.Products.Include(x => x.Discount)
            .Include(x => x.ProductCategory).ToList().AsReadOnly());
    }

    public Task<Product> InsertAsync(Product entity)
    {
        return Task.FromResult(_dbContext.Products.AddAsync(entity).Result.Entity);
    }

    public Task<Product> UpdateAsync(Product entity)
    {
        return Task.FromResult(_dbContext.Products.Update(entity).Entity);
    }

    public Task<Product> DeleteAsync(Product entity)
    {
        return Task.FromResult(_dbContext.Products.Remove(entity).Entity);
    }
}