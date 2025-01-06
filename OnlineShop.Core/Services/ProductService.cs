using OnlineShop.Core.Interfaces.Repository;
using OnlineShop.Core.Interfaces.Service;
using OnlineShop.Core.Model;

namespace OnlineShop.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }

    public Task<List<Product>> GetAllProductsByProductCategoryAsync(string productCategoryName)
    {
        return _productRepository.GetAllAsync();
    }
}