using OnlineShop.Core.Model;

namespace OnlineShop.Core.Interfaces.Service;

public interface IProductCategoryService
{
    Task<List<ProductCategory>> GetAllProductCategoriesAsync();
    Task<ProductCategory?> GetByNameAsync(string name);
}