using OnlineShop.Core.Interfaces.Repository;
using OnlineShop.Core.Interfaces.Service;
using OnlineShop.Core.Model;

namespace OnlineShop.Core.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        this._productCategoryRepository = productCategoryRepository;
    }

    public Task<List<ProductCategory>> GetAllProductCategoriesAsync()
    {
        return _productCategoryRepository.GetAllAsync();
    }

    public Task<ProductCategory?> GetByNameAsync(string name)
    {
        return string.IsNullOrEmpty(name)
            ? Task.FromResult<ProductCategory?>(null)
            : _productCategoryRepository.GetByName(name);
    }
}