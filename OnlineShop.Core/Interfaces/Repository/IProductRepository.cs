using OnlineShop.Core.Model;

namespace OnlineShop.Core.Interfaces.Repository;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetByProductCategoryIdAsync(int categoryId);
}